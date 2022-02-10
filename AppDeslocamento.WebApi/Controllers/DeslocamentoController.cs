using AppDeslocamento.Application.Deslocamentos.Commands;
using AppDeslocamento.Application.Deslocamentos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AppDeslocamento.WebApi.Controllers
{
    public class DeslocamentoController : ApiController
    {
        [HttpPost("iniciar-deslocamento")]
        public async Task<IActionResult> PostIniciarDeslocamentoAsync([FromBody] IniciarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);            

            return Created("", result);
        }        

        [HttpPut("{deslocamentoId:long}/finalizar-deslocamento")]
        public async Task<IActionResult> PutFinalizarDeslocamentoAsync([FromRoute] long deslocamentoId, [FromBody] FinalizarDeslocamentoCommand command)
        {
            command.Id = deslocamentoId;            

            var result = await Mediator.Send(command);            

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetDeslocamentosAsync([FromQuery] GetDeslocamentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetDeslocamentoByIdAsync([FromRoute] long id, [FromQuery] GetDeslocamentoByIdQuery query)
        {
            query.Id = id;
            var result = await Mediator.Send(query);

            return Ok(result);
        }
    }
}
