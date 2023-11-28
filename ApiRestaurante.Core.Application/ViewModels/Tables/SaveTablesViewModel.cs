
using System.Text.Json.Serialization;

namespace ApiRestaurante.Core.Application.ViewModels.Tables
{
    public class SaveTablesViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }

        public int PeopleAmount { get; set; }     

        public string Description { get; set; } 
       
        

    }
}
