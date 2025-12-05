using Desafio.Data.DTOs;

namespace Desafio.Business.Services.Compra
{
    public interface ICompraService
    {
        Task<IEnumerable<CompraDto>> Listar();
        Task<CompraDto?> ObterPorId(Guid id);
        Task<IEnumerable<CompraDto>> ListarPorCliente(Guid clienteId);
        Task<CompraDto> Criar(CompraDto compraDto);
        Task Atualizar(CompraDto compraDto);
        Task<ClienteTotalizadoresDto> ObterTotalizador(Guid clienteId);
        Task Cancelar(Guid id);
        Task<List<ClienteCompraDto>> ListarTopCompradores();
    }
}