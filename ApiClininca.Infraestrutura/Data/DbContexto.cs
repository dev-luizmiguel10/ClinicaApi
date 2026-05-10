using ApiClinica.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClininca.Infraestrutura.Data
{
    public class DbContexto:DbContext
    {
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        public DbContexto(DbContextOptions<DbContexto> options):base(options)
        {
        }
    }
}
