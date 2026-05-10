using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Text;

namespace ApiClinica.Application.Service
{
    public class Cep
    {
        private readonly HttpClient _http;

        public Cep(HttpClient http)
        {
            _http = http;
        }

        public async Task <CepService> BuscarCep(string cep)
        {
            var response = await _http.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            if (!response.IsSuccessStatusCode)
                throw new SystemException("Erro ao consultar CEP");

            var endereco = await response.Content.ReadFromJsonAsync<CepService>();
            return endereco;
            
        }
    }
}
