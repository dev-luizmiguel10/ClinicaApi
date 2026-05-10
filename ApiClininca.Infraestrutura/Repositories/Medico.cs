using ApiClinica.Domain.Repository;
using ApiClininca.Infraestrutura.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClininca.Infraestrutura.Repositories
{
    public class Medico : IMedicoRepository
    {
        private readonly DbContexto _db;
        public Medico(DbContexto db)
        {
         _db= db;   
        }
        public async Task AdicionarMedico(ApiClinica.Domain.Entities.Medico medico)
        {
          var medicos= await _db.Medicos.AddAsync(medico);
           
        }

        async Task<List<ApiClinica.Domain.Entities.Medico>> IMedicoRepository.ListaMedico()
        {
            return await _db.Medicos.ToListAsync();
        }

        async Task<ApiClinica.Domain.Entities.Medico> IMedicoRepository.MedicoById(int id)
        {
           var medico= await _db.Medicos.FirstAsync(s=>s.MedicoId==id);
            return medico;
        }
    }
}
