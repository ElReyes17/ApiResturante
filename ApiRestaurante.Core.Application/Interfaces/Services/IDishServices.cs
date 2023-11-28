
using ApiRestaurante.Core.Application.Interfaces.Services.Generics;
using ApiRestaurante.Core.Application.ViewModels.Dishes;
using ApiRestaurante.Core.Domain.Entities;

namespace ApiRestaurante.Core.Application.Interfaces.Services
{
    public interface IDishServices : IGenericServices<SaveDishesViewModel, DishesViewModel, Dishes>
    {
        Task<DishesViewModel> ShowById(int id);

        Task<string> ValidateCategoryId(int id);

        Task<string> ValidateDishesId(List<int> ids);


    }
}
