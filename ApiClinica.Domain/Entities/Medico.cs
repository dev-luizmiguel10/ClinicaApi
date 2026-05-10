using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiClinica.Domain.Entities
{
    [Table("tb_Medico")]
    public class Medico
    {
        public int MedicoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CRM { get; set; }=string.Empty;
        public string Especialidade { get; set; } = string.Empty;
    }
}
