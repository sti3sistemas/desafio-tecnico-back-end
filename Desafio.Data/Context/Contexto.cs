using Desafio.Data.Entidades;
using Desafio.Data.Helpers;
using Desafio.Data.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data.Context
{
    public class Contexto : DbContext
    {
        private readonly IIdentificadorManipuladorAccessor? _manipuladorAccessor;

        public Contexto(DbContextOptions<Contexto> options, IIdentificadorManipuladorAccessor? manipuladorAccessor = null) : base(options)
        {
            _manipuladorAccessor = manipuladorAccessor;
        }

        #region DbSet
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cliente
            var cliente = modelBuilder.Entity<Cliente>();
            cliente.HasKey(e => e.Id);
            cliente.Property(e => e.Nome).IsRequired().HasMaxLength(250);
            cliente.Property(e => e.Logradouro).IsRequired().HasMaxLength(200);
            cliente.Property(e => e.Numero).IsRequired().HasMaxLength(20);
            cliente.Property(e => e.Bairro).IsRequired().HasMaxLength(100);
            cliente.Property(e => e.CPF).IsRequired().HasMaxLength(14);
            cliente.HasIndex(e => e.CPF).IsUnique();
            cliente.Property(e => e.DataNascimento).IsRequired();
            cliente.Property(e => e.ValorUltimaCompra).HasPrecision(18, 2);
            cliente.Property(e => e.ValorTotalGasto).HasPrecision(18, 2);
            cliente.Property(e => e.ValorTotalPago).HasPrecision(18, 2);
            cliente.Property(e => e.Observacoes).HasMaxLength(500);
            cliente.Property(e => e.Ativo).HasDefaultValue(true);
            cliente.Property(e => e.DataHoraCriacao).HasDefaultValueSql("GETDATE()");

            cliente
                .HasMany(e => e.Compras)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            // Compra
            var compra = modelBuilder.Entity<Compra>();
            compra.HasKey(e => e.Id);
            compra.Property(e => e.ValorTotalCompra).HasPrecision(18, 2);
            compra.Property(e => e.Recebida).HasDefaultValue(false);
            compra.Property(e => e.Status).HasColumnType("varchar(255)").IsRequired();
            compra.HasIndex(e => e.ClienteId);
            compra.Property(e => e.DataHoraCriacao).HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // Preenche automaticamente o IdentificadorManipulador em inserts
            if (_manipuladorAccessor?.Current is Guid atual && atual != Guid.Empty)
            {
                var entries = ChangeTracker.Entries<BaseEntity>()
                    .Where(e => e.State == EntityState.Added);

                foreach (var entry in entries)
                {
                    entry.Entity.IdentificadorManipulador = atual;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
