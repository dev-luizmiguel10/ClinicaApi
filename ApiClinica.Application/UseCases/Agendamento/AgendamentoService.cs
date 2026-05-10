using ApiClinica.Application.DTO;
using ApiClinica.Domain.Entities;
using ApiClinica.Domain.Repository;
using ApiClinica.Exception.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.UseCases.Agendamento
{
    public class AgendamentoService : IAgendamento

    {
        private readonly IAgendamentoRepository _agendar;
        private readonly IunitiOfWork _work;

        public AgendamentoService(IAgendamentoRepository agendamento, IunitiOfWork iuniti)
        {
            _agendar = agendamento;
            _work = iuniti;
        }
        public async Task Agendamento(AgendamentoDto agendamentoDto)
        {
            await ValidarAgendamento(agendamentoDto);
            var agendar_consulta = new Domain.Entities.Agendamento
            {
                MedicoId = agendamentoDto.MedicoId,
                PacienteId = agendamentoDto.PacienteId,
                Status_Agendamento = agendamentoDto.Status_Agendamento,
                data_agendamento = agendamentoDto.data_agendamento

            };
            await _agendar.AgendarConsulta(agendar_consulta);
            await _work.Save();
        }
      
        public async Task ValidarAgendamento(AgendamentoDto agendamentoDto)
        {
            var agendamento = new AgendamentoValidation();
            var validacao_agendamento = agendamento.Validate(agendamentoDto);

            bool medico_existe = await _agendar.MedicoExistente(agendamentoDto.MedicoId);
            bool paciente_existe = await _agendar.PacienteExistente(agendamentoDto.PacienteId);

            bool horario_existe = await _agendar.ExisteHorario(agendamentoDto.MedicoId, agendamentoDto.data_agendamento);

            if (!medico_existe)
            {
                validacao_agendamento.Errors.Add(new FluentValidation.Results.ValidationFailure("medico", MedicoException.Medico_Inexistente));
            }
            if (!paciente_existe)
            {
                validacao_agendamento.Errors.Add(new FluentValidation.Results.ValidationFailure("paciente", MedicoException.Paciente_Inexistente));

            }
            if (horario_existe)
            {
                validacao_agendamento.Errors.Add(new FluentValidation.Results.ValidationFailure("horario", MedicoException.Horario_Marcado));

            }
            
            if (validacao_agendamento.IsValid == false)
            {
                var lista_usuario = validacao_agendamento.Errors.Select(s => s.ErrorMessage).ToList();
                throw new ApiClinica.Exception.Exception.Agendamento.AgendamentoOnException(lista_usuario);

            }
        }

        async Task<Domain.Entities.Agendamento> IAgendamento.AgendamentoEspecefico(int id)
        {
            return await _agendar.AgendamentoById(id);

        }

        async Task<List<Domain.Entities.Agendamento>> IAgendamento.ListaAgendamento()
        {
           return await _agendar.ListaAgendamento();
        }
    }
}
