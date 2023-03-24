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
        modelBuilder.Entity<Categoria>(categoria =>
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p => p.CategoriaId);
            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p => p.Desc);

        });

        modelBuilder.Entity<Tarea>(tarea =>
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p => p.TareaId);
            tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p => p.Desc);
            tarea.Property(p => p.PrioridadTarea);
            tarea.Property(p => p.FechaCreado);

            tarea.Ignore(p => p.Resumen);

        });
    }

}
