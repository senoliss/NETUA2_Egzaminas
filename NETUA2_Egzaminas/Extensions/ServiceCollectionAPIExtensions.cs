using Microsoft.AspNetCore.Identity;
using NETUA2_Egzaminas.API.Interfaces;
using NETUA2_Egzaminas.API.Mappers;
using NETUA2_Egzaminas.API.Services;
using NETUA2_Egzaminas.DAL.Interfaces;
using NETUA2_Egzaminas.DAL.Repositories;

namespace NETUA2_Egzaminas.API.Extensions
{
    public static class ServiceCollectionAPIExtensions
    {
        public static void AddAPIServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IUserInfoMapper, UserInfoMapper>();
            services.AddTransient<IUserResidenceRepository, UserResidenceRepository>();
            services.AddTransient<IUserInfoRepository, UserInfoRepository>();
        }
    }
}
