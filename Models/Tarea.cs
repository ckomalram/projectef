using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace proyef.Models;

// [Table("NombrePerzonalizado")]
public class Tarea
{
    // [Key]
    public Guid TareaId { get; set; }

    // [ForeignKey("CategoriaId")]
    public Guid CategoriaId { get; set; }

    // [Required]
    // [MaxLength(200)]
    public string Titulo { get; set; }
    public string Desc { get; set; }

    public Prioridad PrioridadTarea { get; set; }

    public DateTime FechaCreado { get; set; }

    public virtual Categoria Categoria { get; set; }

    // Omitir campo al momento de generar base de datos
    // [NotMapped]
    [JsonIgnore]
    public string Resumen {get; set;}

}

public enum Prioridad
{
    Baja,
    Media,
    Alta

}