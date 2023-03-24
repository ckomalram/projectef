using Microsoft.EntityFrameworkCore;
using proyef.Models;

namespace proyef.Context;

public class TareaContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }

    //Se crea el constructor con los valores base
    public TareaContext(DbContextOptions<TareaContext> options) : base(options){}

}
