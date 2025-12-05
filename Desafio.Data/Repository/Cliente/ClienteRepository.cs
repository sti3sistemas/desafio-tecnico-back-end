using Desafio.Data.DTOs;

namespace Desafio.Data.Repository.Cliente
{
    public class ClienteRepository : IClienteRepository
    {
        public Task Atualizar(ClienteDto cliente)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClienteDto>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<ClienteDto?> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Inativar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

