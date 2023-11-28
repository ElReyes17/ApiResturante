

using ApiRestaurante.Core.Domain.Common;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class OrderState :  BaseEntityId
    {
        
        public string NameState { get; set; }

      
        //Navigation Properties 
        public ICollection<Orders> Orders { get; set; }

    }
}
