using ApiClinica.Application.DTO;
using ApiClinica.Application.UseCases.Medico;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateMedico([FromServices] IMedico medico, [FromBody] MedicoDto dto)
        {
            await medico.Medico(dto);
            return Created();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ListaMedico([FromServices] IMedico medico)
        {
           var medicos= await medico.ListaMedico();
            return Ok(medicos);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Medico([FromServices] IMedico medico,int id)
        {
             var medico_esp =await medico.MedicoEspecefico(id);
            if (medico_esp==null)
            
                return NotFound();
            
            return Ok(medico_esp);
        }
        
    }
}
