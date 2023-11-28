
using ApiRestaurante.Core.Domain.Common;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class DishCategory : BaseEntityId
    {
        public string CategoryName { get; set; }

        
        //Navigation  Properties
        public ICollection<Dishes> Dishes { get; set; }
    }
}
