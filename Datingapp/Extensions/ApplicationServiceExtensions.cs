using Datingapp.Data;
using Datingapp.interfaces;
using Datingapp.Services;
using Microsoft.EntityFrameworkCore;

namespace Datingapp.Extensions
{
    public   static class ApplicationServiceExtensions
    {
    
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
        
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            }
                ); 
                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                services.AddCors();
                services.AddScoped<ITokenService, TokenService>();

                    
                return services;
        }


        }
}