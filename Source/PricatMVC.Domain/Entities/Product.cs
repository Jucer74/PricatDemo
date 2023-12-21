using PricatMVC.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricatMVC.Domain.Entities;

public class Product: EntityBase
{
    
    [ForeignKey("Category")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "The Description is required")]
    [StringLength(50, ErrorMessage = "The max length for Description is 50 characters")]
    [DisplayName("Description")]
    public string Description { get; set; } = null!;

    [Required(ErrorMessage = "The EanCode is required")]
    [StringLength(13, ErrorMessage = "The max length for EanCode is 50 characters")]
    [DisplayName("EanCode")]
    public string EanCode { get; set; } = null!;

    [Required(ErrorMessage = "The Price is required")]
    [RegularExpression(@"^\d+(\.\d{1,2})?$")]
    [Range(0, 99999999999.99)]
    [DisplayName("Price")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "La Unit is required")]
    [StringLength(20, ErrorMessage = "The max length for Unit is 20 characters")]
    [DisplayName("Unit")]
    public string Unit { get; set; } = null!;
}