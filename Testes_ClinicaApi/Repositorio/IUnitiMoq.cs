using ApiClinica.Domain.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testes_ClinicaApi.Repositorio
{
    public class IUnitiMoq
    {
        public static IunitiOfWork Save()
        {
            var moq = new Mock<IunitiOfWork>();
            return moq.Object;
        }
    }
}
