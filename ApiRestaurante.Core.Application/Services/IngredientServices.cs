
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Repositories.Generics;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services.Generics;
using ApiRestaurante.Core.Application.ViewModels.Ingredients;
using ApiRestaurante.Core.Domain.Entities;
using AutoMapper;

namespace ApiRestaurante.Core.Application.Services
{
    public class IngredientServices : GenericServices<SaveIngredientsViewModel, IngredientsViewModel, Ingredients>, IIngredientServices
    {
        private readonly IIngredientRepository _repository;
        private readonly IMapper _mapper;

        public IngredientServices(IIngredientRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }


        public async Task<string> ValidateIngredientsId(List<int> ids)
        {

            
          
            foreach (int idItem in ids)
            {
                var validation = await _repository.GetById(idItem);
               
                if (validation == null)
                {
                    return "No existen Ingredientes con el Id" + idItem;
                }

            }
           

           
            return null!;


        }
    }
}
