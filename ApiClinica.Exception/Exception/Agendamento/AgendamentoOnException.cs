using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Exception.Exception.Agendamento
{
    public class AgendamentoOnException:AgendamentoException
    {
        public List<string> Erros { get; set; }

        public AgendamentoOnException(List<string> error)
        {
            Erros = error;
        }
    }
}
