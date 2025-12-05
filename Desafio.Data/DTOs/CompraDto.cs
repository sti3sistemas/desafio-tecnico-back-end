using Desafio.Data.Enums;

namespace Desafio.Data.DTOs
{
    public class CompraDto
    {
        public Guid ClienteId { get; set; }
        public DateTime DataHoraCompra { get; set; }
        public decimal ValorTotalCompra { get; set; }
        public bool Recebida { get; set; }
        public StatusOperacao Status { get; set; }
    }
}
