using Desafio.Data.Context;
using Desafio.Data.DTOs;
using Desafio.Data.Entidades;
using Desafio.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data.Repository.Compra
{
    public class CompraRepository : Repository<Entidades.Compra>, ICompraRepository
    {
        public CompraRepository(Contexto db) : base(db) { }

        public async Task<CompraDto> Criar(CompraDto CompraDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompraDto>> Listar()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CompraDto>> ListarPorCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public async Task<CompraDto?> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Atualizar(CompraDto CompraDto)
        {
            throw new NotImplementedException();
        }

        public async Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ClienteCompraDto>> TopCompradores()
        {
            return await DbSet.Select(x => new ClienteCompraDto
            {
                ClienteId = x.ClienteId,
                ClienteNome = x.Cliente.Nome,
                TotalizarCompras = x.Cliente.Compras.Where(x => x.Status.Equals(StatusOperacao.EFETUADA) && x.Recebida).Sum(x => x.ValorTotalCompra),
                Compras = x.Cliente.Compras
                    .Where(x => x.Status.Equals(StatusOperacao.EFETUADA) && x.Recebida)
                    .Select(c => new CompraInfoDto
                    {
                        DataHoraCompra = c.DataHoraCriacao,
                        ValorTotal = c.ValorTotalCompra
                    }).ToList()
            }).ToListAsync();

            //throw new NotImplementedException();
        }
    }
}