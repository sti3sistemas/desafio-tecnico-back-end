using Desafio.Business.Helpers.Notificacao;
using Desafio.Business.Services.Cliente;
using Desafio.Business.Services.Compra;
using Desafio.Data.Context;
using Desafio.Data.Seeds;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Request context + accessor for IdentificadorManipulador
builder.Services.AddHttpContextAccessor();

// Dependency Injection registrations
builder.Services.AddScoped<INotificador, Notificador>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICompraService, CompraService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<Contexto>();
    context.Database.Migrate();

    await context.Database.EnsureCreatedAsync();
    await InicializarBD.SeedAsync(context);
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
