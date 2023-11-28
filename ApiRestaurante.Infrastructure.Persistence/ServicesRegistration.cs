
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Repositories.Generics;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using ApiRestaurante.Infrastructure.Persistence.Repositories;
using ApiRestaurante.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ApiRestaurante.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts

            services.AddDbContext<ApplicationContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));

            #endregion

            #region Repositories

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped<IDishCategoryRepository, DishCategoryRepository>();
            services.AddScoped<ITableRepository, TableRepository>();
            services.AddScoped<ITableStateRepository, TableStateRepository>();
            services.AddScoped<IDishIngredientRepository, DishIngredientRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>(); 
            services.AddScoped<IDishOrderRepository, DishOrderRespository>();
            services.AddScoped<IOrderStateRepository, OrderStateRepository>();

            #endregion

        }
    }
}
