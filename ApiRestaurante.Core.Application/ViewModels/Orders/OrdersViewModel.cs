
using ApiRestaurante.Core.Application.ViewModels.Dishes;
using ApiRestaurante.Core.Domain.Entities;

namespace ApiRestaurante.Core.Application.ViewModels.Orders
{
    public class OrdersViewModel
    {
        public int Id { get; set; }

        public int TableNumber { get; set; }

        public List<DishOrdersViewModel> DishOrders { get; set; }

        public double SubTotal { get; set; }

        public string State { get; set; }




    }
}
