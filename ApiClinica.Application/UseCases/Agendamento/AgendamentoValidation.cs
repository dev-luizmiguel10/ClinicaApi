using ApiClinica.Application.DTO;
using ApiClinica.Exception.Exception;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.UseCases.Agendamento
{
    public class AgendamentoValidation:AbstractValidator<AgendamentoDto>
    {
        public AgendamentoValidation()
        {
            RuleFor(s => s.MedicoId).NotEmpty().WithMessage(MedicoException.Medico_Inexistente);
            RuleFor(s => s.PacienteId).NotEmpty().WithMessage(MedicoException.Paciente_Inexistente);
            RuleFor(s => s.data_agendamento).NotEmpty().WithMessage(MedicoException.Horario_Marcado);
        }
    }
}
