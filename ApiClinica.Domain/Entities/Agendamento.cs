using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApiClinica.Domain.Entities
{
    [Table("tb_Agendamento")]
    public class Agendamento
    {
        public int AgendamentoId { get; set; }

        [ForeignKey("PacienteId")]
        public int PacienteId { get; set; }

        [ForeignKey("MedicoId")]
        public int MedicoId { get; set; }


        public DateTime data_agendamento { get; set; } = DateTime.UtcNow;
        public StatusAgendamento Status_Agendamento { get; set; }

        public Medico Medicos { get; set; }
        public Paciente Pacientes { get; set; }
    }
}
