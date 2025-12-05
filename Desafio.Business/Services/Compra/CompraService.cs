using Desafio.Business.Helpers.Notificacao;
using Desafio.Business.Services.ServiceBase;
using Desafio.Data.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Business.Services.Compra
{
    public class CompraService : BaseService, ICompraService
    {
        private readonly INotificador _notificador;

        public CompraService(INotificador notificador) : base(notificador)
        {
            _notificador = notificador;
        }

        public Task Atualizar(CompraDto CompraDto)
        {
            throw new NotImplementedException();
        }

        public Task<CompraDto> Criar(CompraDto CompraDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompraDto>> Listar()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CompraDto>> ListarPorCliente(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<CompraDto?> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Cancelar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteTotalizadoresDto> ObterTotalizador(Guid clienteId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClienteCompraDto>> ListarTopCompradores()
        {
            throw new NotImplementedException();
        }
    }
}
