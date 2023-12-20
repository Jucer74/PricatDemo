using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PricatMVC.App.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "El Usuario es requerido")]
    [EmailAddress(ErrorMessage = "El Usuario debe ser un email valido")]
    [StringLength(300, ErrorMessage = "La Longitud maxima del usario es de 300 caracteres")]
    [DisplayName("Usuario")]
    public string UserEmail { get; set; } = null!;

    [Required(ErrorMessage = "El Nombre es Requerido")]
    [StringLength(50, ErrorMessage = "La Longitud maxima del Nombre es de 50 caracteres")]
    [DisplayName("Nombre")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "El Apellido es Requerido")]
    [StringLength(50, ErrorMessage = "La Longitud maxima del Apellido es de 50 caracteres")]
    [DisplayName("Apellido")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "La Contraseña es Requerida")]
    [StringLength(20, ErrorMessage = "La Longitud maxima de la Contraseña es de 20 caracteres")]
    [PasswordPropertyText(true)]
    [DisplayName("Contraseña")]
    public string Password { get; set; } = null!;

    [NotMapped]
    [Compare("Password")]
    [StringLength(20, ErrorMessage = "La Longitud maxima de la Confirmacion de la Contraseña es de 20 caracteres")]
    [PasswordPropertyText(true)]
    [DisplayName("Confirmar Contraseña")]
    public string ConfirmPassword { get; set; } = null!;
}