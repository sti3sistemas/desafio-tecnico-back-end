using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Desafio.Data.Context
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();

            // Load connection string from User Secrets
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<ContextoFactory>(optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' não localizada no User Secrets.");
            }

            optionsBuilder.UseSqlServer(connectionString);
            return new Contexto(optionsBuilder.Options);
        }
    }
}
