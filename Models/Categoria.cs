using System.ComponentModel.DataAnnotations;

namespace proyef.Models;

// Con fluent APi los decoradores se comentan
public class Categoria
{
    // [Key]
    public Guid CategoriaId { get; set; }

    // [Required]
    // [MaxLength(150)]
    public string Nombre { get; set; }

    
    public string Desc { get; set; }

    public virtual ICollection<Tarea> Tareas { get; set; }

}