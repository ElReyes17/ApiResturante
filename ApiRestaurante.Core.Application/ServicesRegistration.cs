

using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Interfaces.Services.Generics;
using ApiRestaurante.Core.Application.Services;
using ApiRestaurante.Core.Application.Services.Generics;
using Microsoft.Extensions.DependencyInjection;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using System.Reflection;

namespace ApiRestaurante.Core.Application
{
   public static class ServicesRegistration
    {
        public static void AddCoreApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddScoped(typeof(IGenericServices<,,>), typeof(GenericServices<,,>));
            services.AddScoped<IIngredientServices, IngredientServices>();
            services.AddScoped<IDishServices, DishServices>(); 
            services.AddScoped<ITableServices, TableServices>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddTransient<IUserService, UserServices>();
            #endregion

        }
    }
}
