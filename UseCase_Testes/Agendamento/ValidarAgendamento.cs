using ApiClinica.Application.DTO;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace UseCase_Testes.Agendamento
{
    public class ValidarAgendamento
    {
        public static AgendamentoDto Agendar()
        {
            return new Faker<AgendamentoDto>()
            .RuleFor(s => s.MedicoId, f => f.Random.Int(1, 100))
            .RuleFor(s => s.PacienteId, f => f.Random.Int(1, 100))
            .RuleFor(s => s.data_agendamento, f => f.Date.Future())
            .Generate();
        }
    }
}
