using Desafio.Business.Helpers.Notificacao;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Desafio.API.Controllers
{

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotificador _notificador;

        protected MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool PossuiMensagens()
        {
            return _notificador.PossuiMensagens();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            try
            {
                if (result is null)
                {
                    return NotFound(new
                    {
                        sucesso = true,
                        avisos = "Sem registros",
                        dados = result
                    });
                }

                if (result is Exception)
                {
                    return BadRequest(new
                    {
                        sucesso = false,
                        avisos = "Ocorreu uma falha interna. Verifique a solução!",
                    });
                }

                if (_notificador.PossuiMensagens())
                {
                    return BadRequest(new
                    {
                        sucesso = false,
                        avisos = _notificador.ObterNotificacoes().Select(n => n.Mensagem),
                    });
                }
                else
                {
                    return Ok(new
                    {
                        sucesso = true,
                        dados = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    sucesso = false,
                    erros = new List<string> { ex.ToString() }
                });
            }
        }


        protected void NotificarErro(Exception exception, params object[] dados)
        {
            NotificarErro(exception, true, dados);
        }
    }
}
