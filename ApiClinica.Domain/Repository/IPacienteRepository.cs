using ApiClinica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Domain.Repository
{
    public interface IPacienteRepository
    {
        public Task <Paciente> CriarPaciente(Paciente paciente);
        public Task<List<Paciente>> ListaDePaciente();
        public Task <Paciente> PacienteEspeciente(int id);
    }
}
