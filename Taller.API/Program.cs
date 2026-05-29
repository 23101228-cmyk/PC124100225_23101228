using Microsoft.EntityFrameworkCore;
using Taller.CORE.Infraestructura.Data;
using Taller.CORE.Core.Interfaces;
using Taller.CORE.Core.Services;
using Taller.CORE.Infraestructura.Repositories;

var builder = WebApplication.CreateBuilder(args);

var cnx = builder.Configuration.GetConnectionString("DevConnection");

builder.Services.AddDbContext<TallerMecanicoDbContext>(options =>
    options.UseSqlServer(cnx));
builder.Services.AddScoped<IOrdenServicioRepository, OrdenServicioRepository>();
builder.Services.AddScoped<IOrdenServicioService, OrdenServicioService>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();