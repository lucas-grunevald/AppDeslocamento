using AppDeslocamento.Application.Clientes.Commands.AdicionarCliente;
using AppDeslocamento.Application.Clientes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarClienteCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetClientesAsync([FromQuery] GetClientesQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetClienteByIdAsync([FromRoute] long id, [FromQuery] GetClienteByIdQuery query)
        {
            query.clienteId = id;
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
