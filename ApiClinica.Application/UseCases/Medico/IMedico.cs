using ApiClinica.Application.DTO;
using ApiClinica.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.UseCases.Medico
{
    public interface IMedico
    {
        public Task Medico(MedicoDto medico);
        public Task <List<Domain.Entities.Medico>> ListaMedico();
        public Task <Domain.Entities.Medico> MedicoEspecefico(int id);
    }
}
