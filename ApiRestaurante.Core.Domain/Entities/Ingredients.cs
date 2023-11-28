
using ApiRestaurante.Core.Domain.Common;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class Ingredients : BaseEntityId
    {
        public string Name { get; set; }
      
        
        //Navigation Properties

        public ICollection<DishIngredients> DishIngredients { get; set; }

    }
}
