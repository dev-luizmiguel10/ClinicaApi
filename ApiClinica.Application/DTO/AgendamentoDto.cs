using ApiClinica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.DTO
{
    public class AgendamentoDto
    {
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public DateTime data_agendamento { get; set; } = DateTime.UtcNow;
        public StatusAgendamento Status_Agendamento { get; set; }
    }
}
