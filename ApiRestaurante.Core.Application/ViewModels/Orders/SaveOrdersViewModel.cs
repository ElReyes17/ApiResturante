

using System.Text.Json.Serialization;

namespace ApiRestaurante.Core.Application.ViewModels.Orders
{
    public class SaveOrdersViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
      
        public int TableId { get; set; }

        public List<int> DishOrdersId { get; set; }

        [JsonIgnore]
        public int StateId { get; set; }

        [JsonIgnore]
        public double SubTotal { get; set; }

 
    }
}
