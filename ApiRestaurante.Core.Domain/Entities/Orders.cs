

using ApiRestaurante.Core.Domain.Common;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class Orders : BaseEntityId
    {
        public int TableId { get; set; }

        public int StateId { get; set; }
      
        public double SubTotal { get; set; }

        
        //Navigation Properties 

        public Tables Tables { get; set; }

        public OrderState OrderState { get; set; }

        public ICollection<DishOrders> DishOrders { get; set; }






    }
}
