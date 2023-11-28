
using ApiRestaurante.Core.Application.Interfaces.Repositories;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services.Generics;
using ApiRestaurante.Core.Application.ViewModels.Dishes;
using ApiRestaurante.Core.Domain.Entities;
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System.ComponentModel;

namespace ApiRestaurante.Core.Application.Services
{
   public class DishServices : GenericServices<SaveDishesViewModel, DishesViewModel, Dishes>, IDishServices
    {
     
        private readonly IDishRepository _repository;
        private readonly IDishCategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IDishIngredientRepository _DishingredientRepository;
       
        public DishServices(IDishRepository services, IMapper mapper, 
            IDishCategoryRepository categoryRepository, IDishIngredientRepository ingredientRepository 
           ) : base(services, mapper)
        {
            _mapper = mapper;
            _repository = services;
            _categoryRepository = categoryRepository;
            _DishingredientRepository = ingredientRepository;
           
        }

        public override async Task<List<DishesViewModel>> GetAll()
        {
            var getlist = await _repository.GetAllWithInclude(new List<string> {"DishCategory","DishIngredients.Ingredients" });  
            await _categoryRepository.GetAll();

            var result = getlist.Select(a => new DishesViewModel
            {
                Id = a.Id,
                Name = a.Name,
                PeopleAmount = a.PeopleAmount,
                Price = a.Price,                
                Category = a.DishCategory.CategoryName,
                DishIngredients = _DishingredientRepository.GetIngredientsList(a.Name),
                

            }).ToList();


            return result;

        }

        public async Task<DishesViewModel> ShowById(int id)
        {
            var get = await _repository.GetById(id);
            await _categoryRepository.GetAll();

            DishesViewModel newlist = new DishesViewModel()
            {

                Id = get.Id,
                Name = get.Name,
                Price = get.Price,
                PeopleAmount = get.PeopleAmount,
                Category = get.DishCategory.CategoryName,
                DishIngredients = _DishingredientRepository.GetIngredientsList(get.Name),
             
            };


            return newlist;
           }

        
        



        public override async Task<SaveDishesViewModel> Add(SaveDishesViewModel model)
        {
            var add = new Dishes
            {
                Name = model.Name,
                Price= model.Price,
                PeopleAmount= model.PeopleAmount,
                DishCategoryId= model.DishCategoryId,
                DishIngredients = model.DishIngredientsId.Select(id => new DishIngredients { 
                  
                    IngredientsId = id,
              
                }).ToList(),

            };

            await _repository.Add(add);

            return model;
        }

        public override async Task Update(SaveDishesViewModel model, int id)
        {            
            var dish = await _repository.GetById(id);

            dish.Id = id;
            dish.Name = model.Name;
            dish.PeopleAmount = model.PeopleAmount;
            dish.Price = model.Price;
            dish.DishCategoryId = model.DishCategoryId;

            var ingredient = await _DishingredientRepository.GetDishIngredients(id);
         
            foreach (var item in ingredient)
            {
                await _DishingredientRepository.Delete(item);
            }

            foreach(var a in model.DishIngredientsId)
            {
                dish.DishIngredients.Add(new DishIngredients
                {
                    DishId = dish.Id,
                    IngredientsId = a

                });
            }

            await _repository.Update(dish, id);
        }

        public async Task<string> ValidateCategoryId (int id)
        {
           var validation = await _categoryRepository.GetById(id);

            if(validation == null)
            {
                return $"El Id {id} de la categoria del plato no existe";

            }
            return null!;
        }


        public async Task<string> ValidateDishesId (List<int> ids)
        {
            foreach (var id in ids)
            {
                var validation = await _repository.GetById(id);

                if (validation == null)
                {
                    return "No existen Ingredientes con el Id" + id;
                }

            }
                     
            return null!;
        }




    }
}
