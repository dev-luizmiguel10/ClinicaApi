using ApiClinica.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.UseCases.Paciente
{
    public interface IPaciente
    {
        public Task <PacienteResponseDto> AddUsuario(PacienteDto paciente);
        public Task<List<Domain.Entities.Paciente>> ListaPaciente();
        public Task<Domain.Entities.Paciente> PacienteEspecefico(int id);
    }
}
