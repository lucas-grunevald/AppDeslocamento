using AppDeslocamento.Application.Carros.Commands;
using AppDeslocamento.Application.Carros.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebApi.Controllers
{
    public class CarroController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarCarroCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCarrosAsync([FromQuery] GetCarrosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetCarroByIdAsync([FromRoute] long id, [FromQuery] GetCarroByIdQuery query)
        {
            query.carroId = id;

            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
