using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.DTO
{
    public class PacienteDto
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
       
    }
}
