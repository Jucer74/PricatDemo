using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PricatMVC.App.Models;

public class Category
{
    [Key]
    [Required(ErrorMessage = "El Id es requerido")]
    [DisplayName("Id")]
    public int Id { get; set; } = 0;

    [Required(ErrorMessage = "La Descripcion es requerida")]
    [StringLength(50, ErrorMessage = "La Longitud maxima de la Descripcion es de 50 caracteres")]
    [DisplayName("Descripcion")]
    public string Description { get; set; } = null!;
}