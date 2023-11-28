

using ApiRestaurante.Core.Domain.Common;

namespace ApiRestaurante.Core.Domain.Entities
{
    public class TableState : BaseEntityId
    {       
        public string NameState { get; set; }
      
        
        //Navigation Properties   
        public ICollection<Tables> Tables { get; set; }


        

    }
}
