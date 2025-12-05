namespace Desafio.Business.Helpers.Notificacao
{
    public class Notificador : INotificador
    {
        private readonly List<Notificacao> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        public void Adicionar(Notificacao notificacao, params object[] dados)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes.ToList();
        }

        public bool PossuiMensagens()
        {
            return _notificacoes.Any();
        }
    }
}
