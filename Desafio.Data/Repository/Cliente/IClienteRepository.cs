using Desafio.Data.DTOs;

namespace Desafio.Data.Repository.Cliente
{
    public interface IClienteRepository
    {
        Task<ClienteDto?> ObterPorId(Guid id);
        Task Atualizar(ClienteDto cliente);
        Task Inativar(Guid id);
    }
}