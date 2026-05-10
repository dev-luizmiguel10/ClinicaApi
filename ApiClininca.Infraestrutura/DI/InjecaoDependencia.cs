using ApiClinica.Domain.Repository;
using ApiClininca.Infraestrutura.Data;
using ApiClininca.Infraestrutura.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClininca.Infraestrutura.DI
{
    public static class InjecaoDependencia
    {
        public static void InjecaoDepedencia(this IServiceCollection services,IConfiguration configuration)
        {
            Dbcontexto(services, configuration);
            Repository(services);
        }
        public static void Dbcontexto( IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DbContexto>(u => u.UseSqlServer(configuration.GetConnectionString("Conection")));
        }
        public static void Repository(IServiceCollection services)
        {
            services.AddScoped<IPacienteRepository, Paciente>();
            services.AddScoped<IunitiOfWork, Uniti>();
            services.AddScoped<IMedicoRepository, Medico>();
            services.AddScoped<IAgendamentoRepository, Agendamento>();

        }
    }
}
