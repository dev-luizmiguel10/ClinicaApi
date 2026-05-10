using ApiClinica.Domain.Repository;
using ApiClininca.Infraestrutura.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClininca.Infraestrutura.Repositories
{
    public class Uniti : IunitiOfWork
    {
        private readonly DbContexto _db;
        public Uniti(DbContexto db)
        {
            _db=db;
        }
        public async Task Save()
        {
           await _db.SaveChangesAsync();
        }
    }
}
