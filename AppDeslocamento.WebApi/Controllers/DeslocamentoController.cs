using AppDeslocamento.Application.Deslocamentos.Commands;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebApi.Controllers
{
    public class DeslocamentoController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            if (result == null)
            {
                return BadRequest("");
            }

            return Created($"id={result.Id}", result);
        }

        [HttpPut("{deslocamentoId:long/finalizar-deslocamento}")]
        public async Task<IActionResult> PutAsync([FromRoute] long deslocamentoId, [FromBody] CriarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
