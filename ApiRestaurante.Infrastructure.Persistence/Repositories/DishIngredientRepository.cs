
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using ApiRestaurante.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class DishIngredientRepository : GenericRepository<DishIngredients>, IDishIngredientRepository
    {
        private readonly ApplicationContext _context;

        public DishIngredientRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DishIngredients>> GetDishIngredients(int id)
        {
            var ingredients = await _context.DishIngredients.Where(a => a.DishId == id).ToListAsync();

            return ingredients;
        }

        public List<string> GetIngredientsList(string dish)
        {
            var list = _context.DishIngredients.Where(a => a.Dishes.Name == dish)
                .Select(b => b.Ingredients.Name).ToList();

            return list;
        }



    }
}
