using Desafio.Data.DTOs;

namespace Desafio.Data.Repository.Compra
{
    public interface ICompraRepository
    {
        Task<IEnumerable<CompraDto>> Listar();
        Task<CompraDto?> ObterPorId(Guid id);
        Task<IEnumerable<CompraDto>> ListarPorCliente(Guid clienteId);
        Task<CompraDto> Criar(CompraDto CompraDto);
        Task Atualizar(CompraDto CompraDto);
        Task<List<ClienteCompraDto>> TopCompradores();
        Task Remover(Guid id);
    }
}
