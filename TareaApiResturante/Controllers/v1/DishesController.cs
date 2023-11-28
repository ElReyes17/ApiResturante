using ApiRestaurante.Core.Application.Enums;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.Dishes;
using ApiRestaurante.WebApi.Controllers.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TareaApiResturante.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class DishesController : BaseApiController
    {
        private readonly IDishServices _dishServices;
        private readonly IIngredientServices _ingredientServices;

        public DishesController(IDishServices dishServices, IIngredientServices ingredientServices)
        {
            _dishServices = dishServices;
            _ingredientServices = ingredientServices;
        }


        [HttpGet]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var list = await _dishServices.GetAll();

                if (list.Count == 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No existen Platos");
                }

                return Ok(list);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");

            }




        }




        [HttpGet]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var dishexist = await _dishServices.GetById(id);

                if (dishexist == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "El plato no existe para ese id");
                }

                var dish = await _dishServices.ShowById(id);

                return Ok(dish);


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");
            }

        }


        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] SaveDishesViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var validationCategoryId = await _dishServices.ValidateCategoryId(vm.DishCategoryId);
                var validationIngredientsId = await _ingredientServices.ValidateIngredientsId(vm.DishIngredientsId);

                if (validationCategoryId != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, validationCategoryId);
                }

                else if (validationIngredientsId != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, validationIngredientsId);
                }

                await _dishServices.Add(vm);
                return StatusCode(StatusCodes.Status201Created, "Se ha Creado un Plato");


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");
            }
        }

        [HttpPut]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] SaveDishesViewModel vm, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var validation = await _dishServices.GetById(id);

                if (validation == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "El plato no existe para ese id");
                }

                var validationCategoryId = await _dishServices.ValidateCategoryId(vm.DishCategoryId);
                var validationIngredientsId = await _ingredientServices.ValidateIngredientsId(vm.DishIngredientsId);

                if (validationCategoryId != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, validationCategoryId);
                }

                else if (validationIngredientsId != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, validationIngredientsId);
                }

                await _dishServices.Update(vm, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");
            }

        }


    }
}
