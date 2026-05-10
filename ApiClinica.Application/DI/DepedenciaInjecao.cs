using ApiClinica.Application.Service;
using ApiClinica.Application.UseCases.Agendamento;
using ApiClinica.Application.UseCases.Medico;
using ApiClinica.Application.UseCases.Paciente;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.DI
{
    public static class DepedenciaInjecao
    {
        public static void InjecaoDependenciaApp(this IServiceCollection service)
        {
            Injecao(service);
            Service(service);
        }
        public static void Injecao(IServiceCollection service) {

            service.AddScoped<IPaciente, Paciente>();
            service.AddScoped<IMedico, MedicoRepository>();
            service.AddScoped<IAgendamento, AgendamentoService>();
            
        }
        public static void Service(IServiceCollection service) {

            service.AddHttpClient<Cep>();
            
        }
    }
}
