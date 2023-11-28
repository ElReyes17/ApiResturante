

namespace ApiRestaurante.Core.Domain.Entities
{
    public class DishOrders
    {
        public int DishesId { get; set; }

        public int OrdersId { get; set; }

        public Orders Orders { get; set;}

        public Dishes Dishes { get; set; }

    }
}
