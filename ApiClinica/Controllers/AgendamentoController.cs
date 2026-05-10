using ApiClinica.Application.DTO;
using ApiClinica.Application.UseCases.Agendamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AgendarConsulta( [FromServices] IAgendamento agendar, [FromBody] AgendamentoDto agendamento)
        {
            await agendar.Agendamento(agendamento);
            return Created();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListaConsulta( [FromServices] IAgendamento agendar)
        {
           var agenda= await agendar.ListaAgendamento();
            return Ok(agenda);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Consulta( [FromServices] IAgendamento agendar,int id)
        {
           var agenda= await agendar.AgendamentoEspecefico(id);
            if(agenda==null)
                    return NotFound(new { id= "Nao encontrado" });
            return Ok(agenda);
        }
    }
}
