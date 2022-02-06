using AppDeslocamento.Application.Condutores.Commands;
using AppDeslocamento.Application.Condutores.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebApi.Controllers
{
    public class CondutorController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AdicionarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetCondutoresQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
