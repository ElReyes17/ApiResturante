

namespace ApiRestaurante.Core.Domain.Entities
{
    public class DishIngredients
    {
        public int DishId {get; set;}

        public int IngredientsId {get; set;}

        
        //Navigation Properties
        public Dishes Dishes { get; set;}

        public Ingredients Ingredients { get; set;}
    }
}
