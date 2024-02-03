using Microsoft.AspNetCore.Identity;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.API.Services;

namespace NETUA2_Egzaminas.API.Extensions
{
    public static class ServiceCollectionAPIExtensions
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IJwtService, JwtService>();
        }
    }
}
