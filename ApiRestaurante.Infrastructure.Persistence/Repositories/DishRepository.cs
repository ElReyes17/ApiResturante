
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using ApiRestaurante.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class DishRepository : GenericRepository<Dishes>, IDishRepository
    {
        private readonly ApplicationContext _context;
        public DishRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Dishes>> GetAllWithInclude(List<string> propierties)
        {
            var query = _context.Set<Dishes>().AsQueryable();

            foreach (string propiedad in propierties)
            {
                query.Include(propiedad);
            }

            return await query.ToListAsync();
        }


    }
}
