using ApiClinica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Domain.Repository
{
    public interface IMedicoRepository
    {
        public Task AdicionarMedico(Medico medico);
        public Task<List<Medico>> ListaMedico();
        public Task <Medico> MedicoById(int id);
    }
}
