


using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Domain.Entities;
using ApiRestaurante.Infrastructure.Persistence.Contexts;
using ApiRestaurante.Infrastructure.Persistence.Repositories.Generics;

namespace ApiRestaurante.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        private readonly ApplicationContext _context;

        public OrderRepository(ApplicationContext context) : base(context)
        {
            _context = context;
            
        }

        public List<Orders> GetAllOrders(int tablesId)
        {
            return _context.Orders.Where(a => a.TableId == tablesId).ToList();
        }
    }
}
