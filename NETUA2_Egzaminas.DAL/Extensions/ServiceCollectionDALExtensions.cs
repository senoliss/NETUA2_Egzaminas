using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NETUA2_Egzaminas.DAL.Interfaces;
using NETUA2_Egzaminas.DAL.Repositories;
using NETUA2_Egzaminas.API.Services;

namespace NETUA2_Egzaminas.DAL.Extensions
{
    public static class ServiceCollectionDALExtensions
    {
        public static void AddDatabaseServices(this IServiceCollection services)
        {
            services.AddScoped<IUserManagerService, UserManagerService>();
			services.AddScoped<IImageRepository, ImageRepository>();
		}
    }
}
