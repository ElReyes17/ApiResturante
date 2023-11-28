

using ApiRestaurante.Core.Domain.Common;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class Tables : BaseEntityId
    {

        public int PeopleAmount { get; set; }

        public string Description { get; set; }

        public int StateId { get; set; }

     
        //Navigation Properties
        public TableState TableState { get; set; }

        public ICollection<Orders> Orders { get; set; }

        


    }
}
