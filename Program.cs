using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyef.Context;

var builder = WebApplication.CreateBuilder(args);


//configurando general  EntityFramework core - Base de dato en memoria
// builder.Services.AddDbContext<TareaContext>(p => p.UseInMemoryDatabase("TareasDB"));

// conf EF para sql server
// ICARLYLE\SQLEXPRESS
// "Data Source=SERVIDOR;Initial Catalog=BASE_DE_DATOS;User ID=USUARIO;Password=CONTRASEÑA;"

builder.Services.AddSqlServer<TareaContext>("Data Source=ICARLYLE\\SQLEXPRESS;Initial Catalog=TareasDb;User ID=sa;Password=sa;");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareaContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("DB en memoria " + dbContext.Database.IsInMemory());
});

app.Run();
