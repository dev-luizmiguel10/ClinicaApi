using ApiClinica.Domain.Entities;
using ApiClininca.Infraestrutura.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteIntegracaoClinica.Agendamento
{
    public class AgendamentoFactory:WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(s =>
            {
                var description= s.Where(d=>d.ServiceType==typeof(DbContextOptions<DbContexto>)
                 ||
                d.ServiceType==typeof(DbContextOptions)).ToList();

                foreach (var item in description)
                {
                    s.Remove(item);
                }

                var sql_provider = s.Where(s => s.ServiceType == typeof(IDbContextOptionsConfiguration<DbContexto>)).ToList();

                foreach (var item in sql_provider)
                {
                    s.Remove(item);
                }

                s.AddDbContext<DbContexto>(u => u.UseInMemoryDatabase("db_Api"));

                var sp = s.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var db = scope.ServiceProvider.GetRequiredService<DbContexto>();

                db.Medicos.Add(new Medico { MedicoId = 1, Nome = "Dr. Teste",CRM="3424443244",Especialidade="Odonto" });
                db.Paciente.Add(new Paciente { PacienteId = 1, Nome = "Paciente Teste",CEP="03474055",CPF="50785077871" });
                db.SaveChanges();
            });

        }
    }
}
