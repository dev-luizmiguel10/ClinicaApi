using ApiClinica.Domain.Repository;
using ApiClininca.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClininca.Infraestrutura.Repositories
{
    public class Agendamento : IAgendamentoRepository
    {
        private readonly DbContexto _db;
        public Agendamento(DbContexto db)
        {
            _db = db;
        }

     
        public async Task AgendarConsulta(ApiClinica.Domain.Entities.Agendamento agendamento)
        {
            await _db.Agendamentos.AddAsync(agendamento);
        }



        public async Task<bool> ExisteHorario(int medicoId, DateTime data)
        {
            return await _db.Agendamentos.AnyAsync(a => a.MedicoId == medicoId && a.data_agendamento == data);
        }

       
        public async Task<bool> MedicoExistente(int id)
        {
            var medico = await _db.Medicos.AnyAsync(m => m.MedicoId == id);
            return medico;
        }

        public async Task<bool> PacienteExistente(int id)
        {
            var paciente = await _db.Paciente.AnyAsync(p => p.PacienteId == id);
            return paciente;
        }

        async Task<ApiClinica.Domain.Entities.Agendamento> IAgendamentoRepository.AgendamentoById(int id)
        {
           var agendamento=await _db.Agendamentos.FirstAsync(s=>s.AgendamentoId == id);
            return agendamento;
        }

        async Task<List<ApiClinica.Domain.Entities.Agendamento>> IAgendamentoRepository.ListaAgendamento()
        {
           return await _db.Agendamentos.ToListAsync();
        }
    }
}
