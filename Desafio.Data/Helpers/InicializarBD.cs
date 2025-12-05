using Desafio.Data.Context;
using Desafio.Data.Entidades;
using Desafio.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data.Seeds
{
    public static class InicializarBD
    {
        public static async Task SeedAsync(Contexto context)
        {
            if (context.Cliente.Any()) return;

            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Lucas Freire",
                    Logradouro = "Rua das Palmeiras",
                    Numero = "123",
                    Bairro = "Centro",
                    CPF = "123.456.789-00",
                    DataNascimento = new DateTime(1995, 5, 20),
                    ValorUltimaCompra = 250.75m,
                    ValorTotalGasto = 4500.00m,
                    ValorTotalPago = 4400.00m,
                    Observacoes = "Cliente VIP, sempre paga em dia."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Mariana Souza",
                    Logradouro = "Av. Brasil",
                    Numero = "987",
                    Bairro = "Jardim América",
                    CPF = "987.654.321-00",
                    DataNascimento = new DateTime(1988, 10, 2),
                    ValorUltimaCompra = 120.00m,
                    ValorTotalGasto = 1580.50m,
                    ValorTotalPago = 1580.50m,
                    Observacoes = "Prefere pagamento via PIX."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Rafael Almeida",
                    Logradouro = "Rua das Laranjeiras",
                    Numero = "55",
                    Bairro = "Centro",
                    CPF = "456.789.123-00",
                    DataNascimento = new DateTime(1990, 3, 15),
                    ValorUltimaCompra = 500.00m,
                    ValorTotalGasto = 9500.00m,
                    ValorTotalPago = 9400.00m,
                    Observacoes = "Comprador recorrente, indica novos clientes."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Ana Costa",
                    Logradouro = "Rua Ametista",
                    Numero = "12",
                    Bairro = "Jardim Europa",
                    CPF = "654.987.321-00",
                    DataNascimento = new DateTime(1998, 8, 25),
                    ValorUltimaCompra = 89.90m,
                    ValorTotalGasto = 500.00m,
                    ValorTotalPago = 500.00m,
                    Observacoes = null
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Bruno Martins",
                    Logradouro = "Av. Santos Dumont",
                    Numero = "200",
                    Bairro = "Vila Nova",
                    CPF = "321.654.987-00",
                    DataNascimento = new DateTime(1985, 11, 10),
                    ValorUltimaCompra = 650.00m,
                    ValorTotalGasto = 7850.00m,
                    ValorTotalPago = 7700.00m,
                    Observacoes = "Cliente corporativo."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Fernanda Oliveira",
                    Logradouro = "Rua do Sol",
                    Numero = "999",
                    Bairro = "Boa Vista",
                    CPF = "852.741.963-00",
                    DataNascimento = new DateTime(1993, 6, 5),
                    ValorUltimaCompra = 200.00m,
                    ValorTotalGasto = 1200.00m,
                    ValorTotalPago = 1200.00m,
                    Observacoes = "Gosta de promoções."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Eduardo Lima",
                    Logradouro = "Av. Paulista",
                    Numero = "3000",
                    Bairro = "Bela Vista",
                    CPF = "951.357.852-00",
                    DataNascimento = new DateTime(1980, 9, 12),
                    ValorUltimaCompra = 99.90m,
                    ValorTotalGasto = 2500.00m,
                    ValorTotalPago = 2400.00m,
                    Observacoes = null
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Juliana Ribeiro",
                    Logradouro = "Rua Flor de Lis",
                    Numero = "71",
                    Bairro = "Parque Verde",
                    CPF = "147.258.369-00",
                    DataNascimento = new DateTime(1999, 1, 30),
                    ValorUltimaCompra = 180.00m,
                    ValorTotalGasto = 600.00m,
                    ValorTotalPago = 600.00m,
                    Observacoes = "Cliente nova, boa avaliação."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Pedro Santos",
                    Logradouro = "Rua da Independência",
                    Numero = "404",
                    Bairro = "Liberdade",
                    CPF = "753.159.486-00",
                    DataNascimento = new DateTime(1992, 7, 14),
                    ValorUltimaCompra = 350.00m,
                    ValorTotalGasto = 2250.00m,
                    ValorTotalPago = 2250.00m,
                    Observacoes = "Cliente frequente."
                },
                new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = "Carla Mendes",
                    Logradouro = "Rua Bela Vista",
                    Numero = "700",
                    Bairro = "Centro",
                    CPF = "258.369.147-00",
                    DataNascimento = new DateTime(1991, 12, 3),
                    ValorUltimaCompra = 420.00m,
                    ValorTotalGasto = 3200.00m,
                    ValorTotalPago = 3100.00m,
                    Observacoes = "Prefere entrega por motoboy."
                }
            };

            var compras = new List<Compra>();

            foreach (var cliente in clientes)
            {
                var rng = new Random(cliente.GetHashCode());
                int totalCompras = rng.Next(1, 4);

                for (int i = 0; i < totalCompras; i++)
                {
                    compras.Add(new Compra
                    {
                        Id = Guid.NewGuid(),
                        ClienteId = cliente.Id,
                        ValorTotalCompra = Math.Round((decimal)(rng.NextDouble() * 1000), 2),
                        Recebida = rng.Next(0, 2) == 1,
                        Status = rng.Next(0, 2) == 1 ? StatusOperacao.EFETUADA : StatusOperacao.CANCELADA
                    });
                }
            }

            context.Cliente.AddRange(clientes);
            await context.SaveChangesAsync();
        }
    }
}
