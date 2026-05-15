using ApiClinica.Application.DTO;
using ApiClinica.Application.Service;
using ApiClinica.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.UseCases.Paciente
{
    public class Paciente : IPaciente
    {
        private readonly IPacienteRepository _paciente;
        private readonly IunitiOfWork _uni;
        private readonly Cep _cep;

        public Paciente(IPacienteRepository paciente,IunitiOfWork unit,Cep cep)
        {
            _paciente=paciente;
            _uni=unit;
            _cep=cep;
        }
       

        public async Task<List<Domain.Entities.Paciente>> ListaPaciente()
        {
           return await _paciente.ListaDePaciente();
        }

        public async Task<Domain.Entities.Paciente> PacienteEspecefico(int id)
        {
            return await _paciente.PacienteEspeciente(id);
        }

      public  async Task<PacienteResponseDto> AddUsuario(PacienteDto paciente)
        {
            
            var cep = await _cep.BuscarCep(paciente.CEP);
            var pacientes = new Domain.Entities.Paciente
            {
                Nome = paciente.Nome,
                CPF = paciente.CPF,
                CEP = paciente.CEP,
                Endereco = cep.logradouro
            };

            await _paciente.CriarPaciente(pacientes);
            await _uni.Save();

            return new PacienteResponseDto
            {
                nome = pacientes.Nome
            };
        }
    }
}
