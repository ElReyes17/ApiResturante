

using ApiRestaurante.Core.Application.Interfaces.Repositories.Generics;
using ApiRestaurante.Core.Domain.Entities;

namespace ApiRestaurante.Core.Application.Interfaces.Repositories
{
   public interface IDishIngredientRepository : IGenericRepository<DishIngredients>
    {
        Task<List<DishIngredients>> GetDishIngredients(int id);

        List<string> GetIngredientsList(string dish);

    }
}
