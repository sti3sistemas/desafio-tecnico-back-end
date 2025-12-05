using Desafio.Data.DTOs;

namespace Desafio.Business.Services.Cliente
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> ListarSimples();
        Task<IEnumerable<ClienteDto>> ListarCompleto();
        Task<ClienteDto?> ObterPorId(Guid id);
        Task<ClienteDto> Criar(ClienteDto cliente);
        Task Atualizar(ClienteDto cliente);
        Task Remover(Guid id);
    }
}