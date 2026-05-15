using ApiClinica.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testes_ClinicaApi.Repositorio
{
    public class IAgendamentoRepo
    {
        public static IAgendamentoRepository Agendar()
        {
            var moq= new Mock<IAgendamentoRepository>();
            Mock.Get(moq.Object).Setup(s=>s.MedicoExistente(It.IsAny<int>())).ReturnsAsync(true);
            Mock.Get(moq.Object).Setup(s=>s.PacienteExistente(It.IsAny<int>())).ReturnsAsync(true);
            Mock.Get(moq.Object).Setup(s=>s.ExisteHorario(It.IsAny<int>(),It.IsAny<DateTime>())).ReturnsAsync(false);
            return moq.Object;
        }
    }
}
