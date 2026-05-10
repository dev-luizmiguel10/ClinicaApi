using ApiClinica.Exception.Exception;
using ApiClinica.Exception.Exception.Agendamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ApiClinica.FiltroException
{
    public class FiltroException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is AgendamentoException)
            {
                ValidarAgendamento(context);
            }
            else
            {
                ErroDesconhecido(context); 
            }
        }
        public void ValidarAgendamento(ExceptionContext exception)
        {
            switch (exception.Exception)
            {
                case AgendamentoOnException ex:
                    exception.Result = new BadRequestObjectResult(new AgendamentoErrorList(ex.Erros));
                    exception.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                
            }
        }
        public void ErroDesconhecido(ExceptionContext exception)
        {
            exception.HttpContext.Response.StatusCode=(int)HttpStatusCode.InternalServerError;
            exception.Result = new ObjectResult(new AgendamentoErrorList(MedicoException.Erro_Desconhecido));
        }
    }
}
