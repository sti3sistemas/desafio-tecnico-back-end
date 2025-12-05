namespace Desafio.Data.DTOs
{
    public class ClienteCompraDto
    {
        public Guid ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public decimal TotalizarCompras { get; set; }
        public List<CompraInfoDto> Compras { get; set; }
    }

    public class CompraInfoDto
    {
        public DateTime DataHoraCompra { get; set; }
        public decimal ValorTotal{ get; set; }
    }
}
