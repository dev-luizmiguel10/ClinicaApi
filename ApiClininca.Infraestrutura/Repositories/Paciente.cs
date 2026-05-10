using ApiClinica.Domain.Repository;
using ApiClininca.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClininca.Infraestrutura.Repositories
{
    public class Paciente:IPacienteRepository
    {
        private readonly DbContexto _db;
        public Paciente(DbContexto db)
        {
            _db = db;
        }

        public async Task<ApiClinica.Domain.Entities.Paciente> CriarPaciente(ApiClinica.Domain.Entities.Paciente paciente)
        {
             await  _db.Paciente.AddAsync(paciente);
            return paciente;
        }

        public async Task<List<ApiClinica.Domain.Entities.Paciente>> ListaDePaciente()
        {
            return await _db.Paciente.ToListAsync();
        }

        async Task<ApiClinica.Domain.Entities.Paciente> IPacienteRepository.PacienteEspeciente(int id)
        {
            var paciente=await _db.Paciente.FirstAsync(p=>p.PacienteId==id);
            return paciente;
        }
    }
}
