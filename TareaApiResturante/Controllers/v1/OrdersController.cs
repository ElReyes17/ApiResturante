using ApiRestaurante.Core.Application.Enums;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using ApiRestaurante.Core.Application.ViewModels.Orders;
using ApiRestaurante.WebApi.Controllers.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TareaApiResturante.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Mesero")]
    public class OrdersController : BaseApiController
    {
        private readonly IOrderServices _orderServices;
        private readonly ITableServices _tableServices;
        private readonly IDishServices _dishServices;


        public OrdersController(IOrderServices orderServices, ITableServices tableServices, IDishServices dishServices)
        {
            _orderServices = orderServices;
            _tableServices = tableServices;
            _dishServices = dishServices;
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
                var list = await _orderServices.GetAll();
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
                var orderexist = await _orderServices.GetById(id);

                if (orderexist == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "La orden no existe para ese id");
                }

                var result = await _orderServices.ShowById(id);

                return Ok(result);

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

        public async Task<IActionResult> Create(SaveOrdersViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var validationTable = await _tableServices.ValidateTablesId(vm.TableId);
                var validationDish = await _dishServices.ValidateDishesId(vm.DishOrdersId);

                if (validationTable != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, validationTable);
                }
                else if (validationDish != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, validationDish);
                }

                await _orderServices.Add(vm);
                return StatusCode(StatusCodes.Status201Created, "Se ha Creado una Orden");
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

        public async Task<IActionResult> Update(SaveOrdersViewModel vm, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var validation = await _orderServices.GetById(id);

                if (validation == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "La orden no existe para ese id");
                }

                var validationTable = await _tableServices.ValidateTablesId(vm.TableId);
                var validationDish = await _dishServices.ValidateDishesId(vm.DishOrdersId);

                if (validationTable != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, validationTable);
                }
                else if (validationDish != null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, validationDish);
                }

                await _orderServices.Update(vm, id);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");

            }


        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var validation = await _orderServices.GetById(id);

                if (validation == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "La orden no existe para ese id");
                }

                await _orderServices.Delete(id);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");

            }

        }


    }
}
