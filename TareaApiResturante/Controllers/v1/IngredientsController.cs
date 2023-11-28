using ApiRestaurante.Core.Application.Enums;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.Ingredients;
using ApiRestaurante.WebApi.Controllers.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TareaApiResturante.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class IngredientsController : BaseApiController
    {
        private readonly IIngredientServices _services;

        public IngredientsController(IIngredientServices services)
        {
            _services = services;
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

                var get = await _services.GetAll();

                if (get.Count == 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No existen Ingredientes");

                }

                return Ok(get);
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
                var search = await _services.GetById(id);
                if (search == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No existe un Ingrediente con ese Id");
                }
                return Ok(search);
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> Create([FromBody] SaveIngredientsViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();

                }

                await _services.Add(vm);

                return StatusCode(StatusCodes.Status201Created, "Se ha Creado un Ingrediente");

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

        public async Task<IActionResult> Update([FromBody] SaveIngredientsViewModel vm, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                vm.Id = id;

                var validation = await _services.GetById(id);

                if (validation == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "No existe un Ingrediente con ese Id");
                }

                await _services.Update(vm, id);

                var response = await _services.GetById(id);

                return Ok(response);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");

            }



        }

    }
}
