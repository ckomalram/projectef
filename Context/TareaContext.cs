using Microsoft.EntityFrameworkCore;
using proyef.Models;

namespace proyef.Context;

public class TareaContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    //Se crea el constructor con los valores base
    public TareaContext(DbContextOptions<TareaContext> options) : base(options) { }

    //Fluent API para crear tablas
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Creando Coleccion para agregar datos semilleros.
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136dbaa"), Nombre = "Pendientes", Peso = 20 });
        categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136db02"), Nombre = "Personales", Peso = 20 });

        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Desc).IsRequired(false);
            categoria.Property(p => p.Peso);

            categoria.HasData(categoriasInit);

        });


        // Creando Coleccion para agregar datos semilleros.
        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136db03"), CategoriaId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136db02"), PrioridadTarea = Prioridad.Media, Titulo = "Ejercicio", FechaCreado = DateTime.Now, Desc = "tarea 1" });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136db04"), CategoriaId = Guid.Parse("71c87875-4439-4d7c-ba96-f8ba9136dbaa"), PrioridadTarea = Prioridad.Baja, Titulo = "Supermercado", FechaCreado = DateTime.Now, Desc = "tarea 2" });


        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Desc).IsRequired(false);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreado);

            tarea.Ignore(p => p.Resumen);

            tarea.HasData(tareasInit);

        });
    }

}
