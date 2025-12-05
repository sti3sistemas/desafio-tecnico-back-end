using Desafio.Data.Enums;

namespace Desafio.Data.Entidades
{
    public class Compra : BaseEntity
    {
        public Guid ClienteId { get; set; }
        public decimal ValorTotalCompra { get; set; }
        public bool Recebida { get; set; }
        public StatusOperacao Status { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}
