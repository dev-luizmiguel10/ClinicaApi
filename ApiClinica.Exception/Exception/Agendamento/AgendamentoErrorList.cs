using System;
using System.Collections.Generic;
using System.Text;

namespace ApiClinica.Exception.Exception.Agendamento
{
    public class AgendamentoErrorList
    {
        public List<string> Erros { get; set; }
        public AgendamentoErrorList(List<string> erro)
        {
            Erros = erro;
        }
        public AgendamentoErrorList(string error)
        {
            Erros= new List<string>() { error };
        }
    }
}
