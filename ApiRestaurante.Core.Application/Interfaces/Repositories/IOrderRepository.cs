
using ApiRestaurante.Core.Application.Interfaces.Repositories.Generics;
using ApiRestaurante.Core.Domain.Entities;

namespace ApiRestaurante.Core.Application.Interfaces.Repositories
{
    public interface IOrderRepository : IGenericRepository<Orders>
    {
        List<Orders> GetAllOrders(int tablesId);
    }
}
