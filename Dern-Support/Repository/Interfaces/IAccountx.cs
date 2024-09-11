using Dern_Support.Models.Dto;
using Microsoft.AspNetCore.Identity;

using System.Security.Claims;

namespace MidProject.Repository.Interfaces
{
    public interface IAccountx
    {
        public Task<AccountDto> Register(RegisterdAccountDto registerdAccountDto);
        public Task<AccountDto> AccountAuthentication(string username, string password);
        public Task<AccountDto> LogOut(string username);
        public Task<AccountDto> GetTokens(ClaimsPrincipal claimsPrincipal);
    }
}