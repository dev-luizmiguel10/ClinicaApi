using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Domain.Repository
{
    public interface IunitiOfWork
    {
        public Task Save();
    }
}
