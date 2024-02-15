using Microsoft.Extensions.DependencyInjection;
using NETUA2_Egzaminas.BLL.Interfaces;
using NETUA2_Egzaminas.BLL.Services;

namespace NETUA2_Egzaminas.API.Extensions
{
    public static class ServiceCollectionBLLExtensions
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddTransient<IImageService, ImageService>();
        }
    }
}
