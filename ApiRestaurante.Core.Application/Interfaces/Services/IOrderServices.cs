
using ApiRestaurante.Core.Application.Interfaces.Services.Generics;
using ApiRestaurante.Core.Application.ViewModels.Dishes;
using ApiRestaurante.Core.Application.ViewModels.Orders;
using ApiRestaurante.Core.Domain.Entities;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IOrderServices : IGenericServices<SaveOrdersViewModel, OrdersViewModel, Orders>
    {
        Task<OrdersViewModel> ShowById(int id);

        Task<List<OrdersViewModel>> GetAllOrders(int tablesId);


    }
}
