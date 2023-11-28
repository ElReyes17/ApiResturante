using ApiRestaurante.Core.Application.Interfaces.Repositories.Generics;
using ApiRestaurante.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Core.Application.Interfaces.Repositories
{
    public interface IDishOrderRepository : IGenericRepository<DishOrders>
    {
        Task<List<DishOrders>> GetDishOrders(int id);

        List<Dishes> GetDishList(int id);
    }
}
