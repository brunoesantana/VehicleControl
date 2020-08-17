using Microsoft.Extensions.DependencyInjection;
using VehicleControl.Business;
using VehicleControl.Business.Interface;
using VehicleControl.Data.Context;
using VehicleControl.Data.Interface;
using VehicleControl.Data.Repository;

namespace VehicleControl.Injections
{
    public static class DependencyInjections
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IAnuncioService, AnuncioService>();
            services.AddScoped<IAnuncioRepository, AnuncioRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddSingleton<DataContext>();
        }
    }
}
