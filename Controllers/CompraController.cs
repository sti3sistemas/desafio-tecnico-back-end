using Desafio.API.Controllers;
using Desafio.Business.Helpers.Notificacao;
using Desafio.Business.Services.Compra;
using Desafio.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : MainController
    {
        private readonly ICompraService _compraService;
        private readonly INotificador _notificador;

        public ComprasController(
            ICompraService compraService,
            INotificador notificador) : base(notificador)
        {
            _compraService = compraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompraDto>>> Listar()
        {
            return CustomResponse();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CompraDto?>> ObterPorId(Guid id)
        {
            return CustomResponse();
        }

        [HttpGet("cliente/{clienteId:guid}")]
        public async Task<ActionResult<IEnumerable<CompraDto>>> ListarPorCliente(Guid clienteId)
        {
            return CustomResponse();
        }

        [HttpGet("cliente/{clienteId:guid}/totalizador")]
        public async Task<ActionResult<ClienteTotalizadoresDto>> ObterTotalizador(Guid clienteId)
        {
            return CustomResponse();
        }

        [HttpGet("top-compradores")]
        public async Task<ActionResult<List<ClienteCompraDto>>> ListarTopCompradores()
        {
            return CustomResponse();
        }

        [HttpPost]
        public async Task<ActionResult<CompraDto>> Criar([FromBody] CompraDto dto)
        {
            return CustomResponse();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] CompraDto dto)
        {
            return CustomResponse();
        }

        [HttpPost("{id:guid}/cancelar")]
        public async Task<IActionResult> Cancelar(Guid id)
        {
            return CustomResponse();
        }
    }
}

