using Dyder.Application.Services;
using Dyder.Repository.Repositories;
using Dyder.Repository.Repositories.Interfaces;
using Dyder.Application.Services.Interfaces;

namespace Dyder.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IEstabelecimentoService, EstabelecimentoService>();
        }    
        
        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEstabelecimentoRepository, EstabelecimentoRepository>();
        }
    }
}
