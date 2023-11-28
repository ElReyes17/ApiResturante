
namespace ApiRestaurante.Core.Application.ViewModels.Dishes
{
   public class DishesViewModel
    {
        public int Id { get; set; } 
       
        public string Name { get; set; }

        public double Price { get; set; }

        public int PeopleAmount { get; set; }

        public string Category {get; set; }

        public List<string> DishIngredients { get; set; }



    }
}
