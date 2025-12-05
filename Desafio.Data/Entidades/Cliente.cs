namespace Desafio.Data.Entidades
{
    public class Cliente : BaseEntity
    {
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal ValorUltimaCompra { get; set; }
        public decimal ValorTotalGasto { get; set; }
        public decimal ValorTotalPago { get; set; }
        public string? Observacoes { get; set; }

        public ICollection<Compra> Compras { get; set; }
    }
}
