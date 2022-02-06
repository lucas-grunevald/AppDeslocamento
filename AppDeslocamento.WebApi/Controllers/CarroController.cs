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
        public async Task<IActionResult> GetAsync([FromQuery] GetCarrosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{carroId:long}")]
        public async Task<IActionResult> GetAsync([FromRoute]long carroId, [FromQuery] GetCarroByIdQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
