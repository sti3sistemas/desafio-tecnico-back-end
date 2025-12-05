using Desafio.Business.Helpers.Notificacao;
using Desafio.Data.Helpers;
using FluentValidation;

namespace Desafio.Business.Services.ServiceBase
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void NotificarMensagem(string mensagem)
        {
            _notificador.Adicionar(new Notificacao(mensagem));
        }
        protected void Notificar(FluentValidation.Results.ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                NotificarMensagem(error.ErrorMessage);
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : FluentValidationType
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}