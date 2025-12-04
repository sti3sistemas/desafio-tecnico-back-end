using Desafio.API.Controllers;
using Desafio.Business.Helpers.Notificacao;
using Desafio.Business.Services.Cliente;
using Desafio.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : MainController
    {
        private readonly IClienteService _clienteService;

        public ClientesController(
            IClienteService clienteService,
            INotificador notificador) : base(notificador)
        {
            _clienteService = clienteService;
        }

        [HttpGet("simples")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ListarSimples()
        {
            return CustomResponse();
        }

        [HttpGet("completo")]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> ListarCompleto()
        {
            return CustomResponse();
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ClienteDto?>> ObterPorId(Guid id)
        {
            return CustomResponse();
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Criar([FromBody] ClienteDto dto)
        {
            return CustomResponse();
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ClienteDto dto)
        {
            return CustomResponse();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            return CustomResponse();
        }
    }
}
