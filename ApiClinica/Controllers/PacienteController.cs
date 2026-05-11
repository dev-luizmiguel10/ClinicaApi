using ApiClinica.Application.DTO;
using ApiClinica.Application.UseCases.Paciente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        [ProducesResponseType(typeof(PacienteResponseDto),StatusCodes.Status201Created)]
        [HttpPost]
        public  async Task<IActionResult> RegisterPaciente([FromServices]IPaciente ipaciente,[FromBody]PacienteDto pacientes)
        {
           var paciente= await ipaciente.AddUsuario(pacientes);

            return Created(string.Empty,paciente);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public  async Task<IActionResult> ListaPaciente([FromServices]IPaciente ipaciente)
        {
           var paciente= await ipaciente.ListaPaciente();
            return Ok(paciente);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Paciente([FromServices] IPaciente ipaciente,int id)
        {
            var paci=await ipaciente.PacienteEspecefico(id);
            if (paci==null)
            {
                return NotFound();
            }
            return Ok(paci);
        }

    }
}
