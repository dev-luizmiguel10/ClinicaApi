using ApiClinica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Domain.Repository
{
    public interface IAgendamentoRepository
    {
        public Task AgendarConsulta(Agendamento agendamento);

        public Task<bool> MedicoExistente(int id);
        public Task<bool> PacienteExistente(int id);
        Task<bool> ExisteHorario(int medicoId, DateTime data);

        public Task<List<Agendamento>> ListaAgendamento();
        public Task<Agendamento> AgendamentoById(int id);
    }
}
