using ApiClinica.Application.UseCases.Agendamento;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Testes_ClinicaApi.Repositorio;

namespace Testes_ClinicaApi
{
    public class Testes_Api_Clinica
    {
        [Fact]
        public async Task Sucess()
        {
            var criar_agendamento = UseCase_Testes.Agendamento.ValidarAgendamento.Agendar();

            var agenda = IAgendamentoRepo.Agendar();
            var save = IUnitiMoq.Save();
            
            var agendamento = new AgendamentoService(agenda, save);

            await agendamento.Agendamento(criar_agendamento);

           Assert.True(true);
        }
        [Fact]
        public void Paciente_Inexistente()
        {
            var criar_agendamento = UseCase_Testes.Agendamento.ValidarAgendamento.Agendar();
            criar_agendamento.PacienteId = 0;

            var testes_agendamento = new ApiClinica.Application.UseCases.Agendamento.AgendamentoValidation();

            var teste = testes_agendamento.Validate(criar_agendamento);
            Assert.False(teste.IsValid);
        }
        [Fact]
        public void Medico_Inexistente()
        {
            var criar_agendamento = UseCase_Testes.Agendamento.ValidarAgendamento.Agendar();
            criar_agendamento.MedicoId = 0;

            var testes_agendamento = new ApiClinica.Application.UseCases.Agendamento.AgendamentoValidation();

            var teste = testes_agendamento.Validate(criar_agendamento);
            Assert.False(teste.IsValid);
        }
        [Fact]
        public void Data_Inexistente()
        {
            var criar_agendamento = UseCase_Testes.Agendamento.ValidarAgendamento.Agendar();
            criar_agendamento.data_agendamento = DateTime.MinValue;

            var testes_agendamento = new ApiClinica.Application.UseCases.Agendamento.AgendamentoValidation();

            var teste = testes_agendamento.Validate(criar_agendamento);
            Assert.False(teste.IsValid);
        }
    }
}
