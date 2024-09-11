using Microsoft.AspNetCore.Identity;

using MidProject.Repository.Interfaces;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Dern_Support.Models.Dto;
using Microsoft.DotNet.Scaffolding.Shared;
using Dern_Support.Models;
using Dern_Support.Data;

namespace MidProject.Repository.Services
{
    public class IdentityAccountService : IAccountx
    {
        private readonly UserManager<ApplicationUser> _accountManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private  JwtTokenService _jwtTokenService;
        private readonly DernSupportDbContext _context;

        public IdentityAccountService(
            UserManager<ApplicationUser> accountManager,
            SignInManager<ApplicationUser> signInManager,
            JwtTokenService jwtTokenService,
            DernSupportDbContext context)
        {
            _accountManager = accountManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
            _context = context;
        }

        public async Task<AccountDto> Register(RegisterdAccountDto registerdAccountDto)
        {
            // Validate roles
            var validRoles = new List<string> { "Customer", "Technician" };
            foreach (var role in validRoles) {
                    if (!validRoles.Contains(role))
                    {
                        throw new ArgumentException($"Invalid role: {role}. Allowed roles are: Admin, Client, Owner, Servicer.");
                    }
                
            }
            //============
            var account = new ApplicationUser()
            {
                UserName = registerdAccountDto.Name,
                Email = registerdAccountDto.Email,
                
                
            };

            var result = await _accountManager.CreateAsync(account, registerdAccountDto.Password);
            
            if (result.Succeeded)
            {
                await _accountManager.AddToRolesAsync(account, registerdAccountDto.Role);


                await _context.SaveChangesAsync();

                return new AccountDto
                {
                    Id = account.Id,
                    UserName = account.UserName,
                    Token = await _jwtTokenService.GenerateToken(account, TimeSpan.FromMinutes(60)),
                    Role = await _accountManager.GetRolesAsync(account)
                };
            }

            throw new Exception("User creation failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        public async Task<AccountDto> AccountAuthentication(string username, string password)
        {
            var account = await _accountManager.FindByNameAsync(username);
            if (account == null || !await _accountManager.CheckPasswordAsync(account, password))
            {
                throw new Exception("Invalid username or password.");
            }

            return new AccountDto
            {
                Id = account.Id,
                UserName = account.UserName,
                Token = await _jwtTokenService.GenerateToken(account, TimeSpan.FromMinutes(60)),
                Role = await _accountManager.GetRolesAsync(account)
            };
        }

        public async Task<AccountDto> LogOut(string username)
        {
            var account = await _accountManager.FindByNameAsync(username);
            if (account == null)
            {
                throw new Exception("Account not found.");
            }

            await _signInManager.SignOutAsync();

            return new AccountDto
            {
                Id = account.Id,
                UserName = account.UserName
            };
        }

        

        public async Task<AccountDto> GetTokens(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _accountManager.GetUserAsync(claimsPrincipal);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return new AccountDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Token = await _jwtTokenService.GenerateToken(user, TimeSpan.FromMinutes(5))
            };
        }
    }
}


