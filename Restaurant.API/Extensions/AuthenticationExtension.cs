using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Restaurant.API.Extensions
{
    public static class AuthenticationExtension
    {
        public static void AddJWTAuthenticationValidation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
                opt.TokenValidationParameters = 
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,            // Validate user 
                    ValidateIssuer = true,              // Token Provider Validation
                    ValidateLifetime = true,            // Token expire after specified time
                    ValidateIssuerSigningKey = true,    // Token encryption key validation
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidAudience = configuration["Toke:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                    ClockSkew = TimeSpan.Zero, // Sets the time difference between different time zones
                }
            );
        }
    }
}