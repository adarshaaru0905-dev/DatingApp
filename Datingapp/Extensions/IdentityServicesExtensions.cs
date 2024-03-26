using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Datingapp.Extensions
{
    
    
    
    public   static class IdentityServicesExtensions
    {
    
        public static IServiceCollection AddIdenityServices(this IServiceCollection services, IConfiguration config)
        {
                    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer
            (options =>
            
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey=true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config ["TokenKey"])),
                    ValidateIssuer= false,
                    ValidateAudience =false,
                };

            });
            return services;
            
        }    
       }
}