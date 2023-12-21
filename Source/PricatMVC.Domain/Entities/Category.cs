using PricatMVC.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PricatMVC.Domain.Entities;

public class Category:EntityBase
{
    [Required(ErrorMessage = "The Description is required")]
    [StringLength(50, ErrorMessage = "The max length for Description is 50 characters")]
    [DisplayName("Description")]
    public string Description { get; set; } = null!;
}