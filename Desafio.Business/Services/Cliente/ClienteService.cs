using Desafio.Business.Helpers.Notificacao;
using Desafio.Business.Services.ServiceBase;
using Desafio.Data.DTOs;
using Desafio.Data.Repository.Cliente;

namespace Desafio.Business.Services.Cliente
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly INotificador _notificador;
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(INotificador notificador) : base(notificador)
        {
            _notificador = notificador;
        }

        public Task Atualizar(ClienteDto cliente)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDto> Criar(ClienteDto cliente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteDto>> ListarSimples()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteDto>> ListarCompleto()
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDto?> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            //validar se cliente tem compras antes de remover

            throw new NotImplementedException();
        }
    }
}
