

using ApiRestaurante.Core.Domain.Common;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class Dishes : BaseEntityId
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int PeopleAmount { get; set; }

        public int DishCategoryId { get; set; }
        
        //Navigation Properties
        
        public DishCategory DishCategory { get; set;}

        public ICollection<DishOrders> DishOrders { get; set; }

        public ICollection<DishIngredients> DishIngredients { get; set; }

    }
}
