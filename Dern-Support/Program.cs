
using Microsoft.EntityFrameworkCore;
using Dern_Support.Data;
using Microsoft.AspNetCore.Identity;
using Dern_Support.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MidProject.Repository.Services;
using MidProject.Repository.Interfaces;
using Microsoft.OpenApi.Models;
using Dern_Support.Repository.Interfaces;
using Dern_Support.Repository.Services;
using Dern_Support.Interfaces;



namespace Dern_Support
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();


            string ConnectionStringVar = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<DernSupportDbContext>(optionsX => optionsX.UseSqlServer(ConnectionStringVar));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<DernSupportDbContext>();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = JwtTokenService.ValidatToken(builder.Configuration);
            });

            builder.Services.AddScoped<IAccountx, IdentityAccountService>();
            builder.Services.AddScoped<ICustomer, CustomerServices>();
            builder.Services.AddScoped<ITechnician, TechnicianServices>();



            builder.Services.AddScoped<JwtTokenService>();

            // Add CORS policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:3000")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });




            // Swagger configuration
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Dern Support API",
                    Version = "v1",
                    Description = "API for Dern Support"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Please enter user token below."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });


            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowReactApp");
            //call swagger services 
            app.UseSwagger
                (
                options =>
                {
                    options.RouteTemplate = "api/{documentName}/swagger.json";
                }
                );
            //call swagger UI
            app.UseSwaggerUI
                (
                options =>
                {
                    options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify Api");
                    options.RoutePrefix = "";
                }
                );

            app.MapControllers();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
