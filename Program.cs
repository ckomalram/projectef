using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyef.Context;

var builder = WebApplication.CreateBuilder(args);


//configurando general  EntityFramework core - Base de dato en memoria
// builder.Services.AddDbContext<TareaContext>(p => p.UseInMemoryDatabase("TareasDB"));

// conf EF para sql server
// ICARLYLE\SQLEXPRESS
// Boiler plate: "Data Source=SERVIDOR;Initial Catalog=BASE_DE_DATOS;User ID=USUARIO;Password=CONTRASEÑA;"
//Enzalando el string a appsettings.json
builder.Services.AddSqlServer<TareaContext>(builder.Configuration.GetConnectionString("cnTareas"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async ([FromServices] TareaContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("DB en memoria " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas",  async ( [FromServices] TareaContext dbContext) =>
{
    //  return Results.Ok(dbContext.Tareas.Where(p => p.PrioridadTarea == proyef.Models.Prioridad.Baja ) );
    //  return Results.Ok(dbContext.Tareas );
    //  return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
     return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == proyef.Models.Prioridad.Baja ) );


});


app.Run();
