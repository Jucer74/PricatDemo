using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PricatMVC.Domain.Common;

public abstract class EntityBase
{
    [Key]
    [Required(ErrorMessage = "The Id is required")]
    [DisplayName("Id")]
    public int Id { get; set; }
}