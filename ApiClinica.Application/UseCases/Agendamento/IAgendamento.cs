using ApiClinica.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.UseCases.Agendamento
{
    public interface IAgendamento
    {
        public Task Agendamento(AgendamentoDto agendamentoDto);
        public Task<List<Domain.Entities.Agendamento>> ListaAgendamento();
        public Task<Domain.Entities.Agendamento> AgendamentoEspecefico(int id);
    }
}
