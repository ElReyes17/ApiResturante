using ApiRestaurante.Core.Application.Dtos;
using ApiRestaurante.Core.Application.Enums;
using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.ViewModels.Tables;
using ApiRestaurante.WebApi.Controllers.v1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace TareaApiResturante.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    public class TablesController : BaseApiController
    {
        private readonly ITableServices _tableServices;
        private readonly IOrderServices _orderServices;

        public TablesController(ITableServices tableServices, IOrderServices orderServices)
        {
            _tableServices = tableServices;
            _orderServices = orderServices;
        }

        [HttpGet]
        [Authorize(Roles = "Mesero, Admin")]
        [Route("List")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            try
            {
                var list = await _tableServices.GetAll();

                if (list.Count == 0)
                {
                    return StatusCode(StatusCodes.Status204NoContent, "No existen Mesas");
                }

                return Ok(list);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");
            }



        }

        [HttpGet]
        [Authorize(Roles = "Mesero, Admin")]
        [Route("GetById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {

                var tableexist = await _tableServices.GetById(id);

                if (tableexist == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "La mesa no existe para ese id");
                }
                var table = await _tableServices.ShowById(id);

                return Ok(table);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");
            }


        }


        [HttpGet]
        [Authorize(Roles = "Mesero")]
        [Route("GetTableOrden/{id}")]

        public async Task<IActionResult> GetTableOrden(int id)
        {
            try
            {
                var table = await _tableServices.GetById(id);

                if (table == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "La mesa no existe para ese id");
                }
                var orders = await _orderServices.GetAllOrders(id);

                return Ok(orders);


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");

            }

        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] SaveTablesViewModel vm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                await _tableServices.Add(vm);
                return StatusCode(StatusCodes.Status201Created, "Se ha Creado una Mesa");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");
            }

        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("Update/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update([FromBody] SaveTablesViewModel vm, int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var validation = await _tableServices.GetById(id);

                if (validation == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "La Mesa no existe para ese id");
                }

                await _tableServices.Update(vm, id);
                return Ok();


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");
            }



        }

        [HttpPut]
        [Authorize(Roles = "Mesero")]
        [Route("ChangeStatus/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusRequest request, int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var validation = await _tableServices.GetById(id);

                if (validation == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "La Mesa no existe para ese id");
                }

                request.Id = id;
                await _tableServices.ChangeStatus(request);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Oh, AH ocurrido un error en el Servidor");
            }

        }









    }
}
