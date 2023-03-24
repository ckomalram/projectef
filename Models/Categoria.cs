namespace proyef.Models;

public class Categoria
{
    public Guid CategoriaId { get; set; }
    public string Nombre { get; set; }
    public string Desc { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }

}