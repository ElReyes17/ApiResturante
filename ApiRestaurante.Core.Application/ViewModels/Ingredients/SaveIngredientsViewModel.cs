

using System.Text.Json.Serialization;

namespace ApiRestaurante.Core.Application.ViewModels.Ingredients
{
    public class SaveIngredientsViewModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
