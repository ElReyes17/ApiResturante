
using ApiRestaurante.Core.Application.ViewModels.Ingredients;
using System.Text.Json.Serialization;

namespace ApiRestaurante.Core.Application.ViewModels.Dishes
{
    public class SaveDishesViewModel
    {
        [JsonIgnore]
        public int Id { get; set; } 

        public string Name { get; set; }

        public double Price { get; set; }

        public int PeopleAmount { get; set; }

        public int DishCategoryId { get; set; }

        public List<int> DishIngredientsId { get; set; }

        
    }
}
