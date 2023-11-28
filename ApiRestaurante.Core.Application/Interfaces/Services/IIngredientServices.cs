
using ApiRestaurante.Core.Application.Interfaces.Services.Generics;
using ApiRestaurante.Core.Application.ViewModels.Ingredients;
using ApiRestaurante.Core.Domain.Entities;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IIngredientServices : IGenericServices<SaveIngredientsViewModel, IngredientsViewModel, Ingredients>
    {
        Task<string> ValidateIngredientsId(List<int> ids);

    }
}
