using ApiClinica.Application.DTO;
using Azure;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace TesteIntegracaoClinica.Agendamento
{
    public class AgendamentoFact:IClassFixture<AgendamentoFactory>
    {
        private readonly HttpClient _http;
        public AgendamentoFact(AgendamentoFactory agendamento)
        {
            _http = agendamento.CreateClient();
        }

        [Fact]
        public async Task Sucesso()
        {
            var agendamento = new AgendamentoDto
            {
                MedicoId = 1,
                PacienteId = 1,
                data_agendamento = DateTime.Now,

            };
            var request = await _http.PostAsJsonAsync("/api/Agendamento", agendamento);

            Assert.Equal(HttpStatusCode.Created, request.StatusCode);
        }
        [Fact]
        public async Task Medico_Inexistente()
        {
            var medico = new AgendamentoDto { MedicoId = 0 };

            var request = await _http.PostAsJsonAsync("/api/Agendamento", medico);
            Assert.Equal(HttpStatusCode.BadRequest, request.StatusCode);
        }

        [Fact]
        public async Task Paciente_Inexistente()
        {
            var paciente = new AgendamentoDto { PacienteId = 0 };

            var request = await _http.PostAsJsonAsync("/api/Agendamento", paciente);
            Assert.Equal(HttpStatusCode.BadRequest, request.StatusCode);
        }
        [Fact]
        public async Task Data_Medico_Marcada()
        {
            var data_medico = new AgendamentoDto
            {
                MedicoId = 1,
                data_agendamento = DateTime.Now
            };

            var request = await _http.PostAsJsonAsync("/api/Agendamento", data_medico);
            Assert.Equal(HttpStatusCode.BadRequest, request.StatusCode);
        }
    }
}
