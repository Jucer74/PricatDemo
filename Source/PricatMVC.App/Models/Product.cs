using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricatMVC.App.Models;

public class Product
{
    [Key]
    [Required(ErrorMessage = "El Id es requerido")]
    [DisplayName("Id")]
    public int Id { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "La Descripcion es requerida")]
    [StringLength(50, ErrorMessage = "La Longitud maxima de la Descripcion es de 50 caracteres")]
    [DisplayName("Descripcion")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "El EanCode es requerido")]
    [StringLength(13, ErrorMessage = "La Longitud maxima del EanCode es de 13 caracteres")]
    [DisplayName("EanCode")]
    public string EanCode { get; set; } = null!;

    [Required(ErrorMessage = "El Precio es requerido")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$")]
    [Range(0, 99999999999.99)]
    [DisplayName("Precio")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "La Unidad es requerida")]
    [StringLength(20, ErrorMessage = "La Longitud maxima del EanCode es de 20 caracteres")]
    [DisplayName("Unidad")]
    public string Unit { get; set; } = null!;
}