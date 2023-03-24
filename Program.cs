using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyef.Context;
using proyef.Models;

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

app.MapGet("/api/tareas", async ([FromServices] TareaContext dbContext) =>
{
    //  return Results.Ok(dbContext.Tareas.Where(p => p.PrioridadTarea == proyef.Models.Prioridad.Baja ) );
    return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
    //  return Results.Ok(dbContext.Tareas.Include(p => p.Categoria));
    // return Results.Ok(dbContext.Tareas.Include(p => p.Categoria).Where(p => p.PrioridadTarea == proyef.Models.Prioridad.Baja));


});

app.MapPost("/api/tareas", async ([FromServices] TareaContext dbContext, [FromBody] Tarea tarea) =>
{
    tarea.TareaId = Guid.NewGuid();
    tarea.FechaCreado = DateTime.Now;
    // opcion 1
    await dbContext.AddAsync(tarea);

    // opcion 2
    // await dbContext.Tareas.AddAsync(tarea);

    await dbContext.SaveChangesAsync();
    return Results.Ok();

});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareaContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    // Por defecto busca la key que esta marcada en el model
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null)
    {
        tareaActual.CategoriaId = tarea.CategoriaId;
        tareaActual.Titulo = tarea.Titulo;
        tareaActual.PrioridadTarea = tarea.PrioridadTarea;
        tareaActual.Desc = tarea.Desc;

        await dbContext.SaveChangesAsync();

        return Results.Ok();

    }



    return Results.NotFound();

});


app.MapDelete("/api/tareas/{id}", async ([FromServices] TareaContext dbContext, [FromRoute] Guid id) =>
{
    // Por defecto busca la key que esta marcada en el model
    var tareaActual = dbContext.Tareas.Find(id);

    if (tareaActual != null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }

    return Results.NotFound();

});



app.Run();
