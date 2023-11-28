

using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Repositories.Generics;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using ApiRestaurante.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class DishCategoryRepository : GenericRepository<DishCategory>, IDishCategoryRepository
    {
        private readonly ApplicationContext _context;

        public DishCategoryRepository(ApplicationContext context) :  base(context)
        {
            _context = context;
        }

        public override async Task<List<DishCategory>> GetAll()
        {
            return await _context.Set<DishCategory>().ToListAsync();
        }

    }
}
