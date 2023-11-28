using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using ApiRestaurante.Infrastructure.Persistence.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class DishOrderRespository : GenericRepository<DishOrders>, IDishOrderRepository
    {
        private readonly ApplicationContext _context;

        public DishOrderRespository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DishOrders>> GetDishOrders(int id)
        {
            var orders = await _context.DishOrders.Where(a => a.OrdersId == id).ToListAsync();

            return orders;
        }

        public List<Dishes> GetDishList(int id)
        {
            var list = _context.DishOrders.Where(a => a.Orders.Id == id)
               .Select(b => b.Dishes).ToList();

            return list;

        }
    }
}
