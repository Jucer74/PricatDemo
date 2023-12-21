using PricatMVC.Domain.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricatMVC.Domain.Entities;

public class User: EntityBase
{
    [Required(ErrorMessage = "The User is required")]
    [EmailAddress(ErrorMessage = "The User must be a valid email")]
    [StringLength(300, ErrorMessage = "The max length for User is 300 characters")]
    [DisplayName("User")]
    public string UserEmail { get; set; } = null!;

    [Required(ErrorMessage = "The FirstName is required")]
    [StringLength(50, ErrorMessage = "The max length for FirstName is 50 characters")]
    [DisplayName("FirstName")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "The LastName is required")]
    [StringLength(50, ErrorMessage = "The max length for LastName is 50 characters")]
    [DisplayName("LastName")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "The Password is required")]
    [StringLength(20, ErrorMessage = "The max length for Password is 20 characters")]
    [PasswordPropertyText(true)]
    [DisplayName("Password")]
    public string Password { get; set; } = null!;

    [NotMapped]
    [Compare("Password")]
    [StringLength(20, ErrorMessage = "The max length for ConfirmPassword is 20 characters")]
    [PasswordPropertyText(true)]
    [DisplayName("Confirm Password")]
    public string ConfirmPassword { get; set; } = null!;
}