using ApiClinica.Application.DTO;
using ApiClinica.Domain.Entities;
using ApiClinica.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Application.UseCases.Medico
{
    public class MedicoRepository : IMedico
    {
        private readonly IMedicoRepository _medico;
        private readonly IunitiOfWork _unit;
        public MedicoRepository(IMedicoRepository medico,IunitiOfWork ofWork)
        {
            _medico = medico;
            _unit = ofWork;
        }

        public async Task<List<Domain.Entities.Medico>> ListaMedico()
        {
            return await _medico.ListaMedico();
        }

        public async Task Medico(MedicoDto medico)
        {
            var medicos = new Domain.Entities.Medico
            {
                CRM = medico.CRM,
                Especialidade = medico.Especialidade,
                Nome = medico.Nome,
            };
            await _medico.AdicionarMedico(medicos);
            await _unit.Save();
        }

        public async Task<Domain.Entities.Medico> MedicoEspecefico(int id)
        {
            return await _medico.MedicoById(id);
            
        }

        //async Task<int> IMedico.MedicoEspecefico(int id)
        //{
        //    return await _medico.MedicoById(id);
        //}
    }
}
