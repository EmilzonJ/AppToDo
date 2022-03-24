using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.Users.Requests;

public class UpsertUserRequest
{
    [Required(ErrorMessage = "Este campo es requerido")]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Este campo es requerido")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
    public string Email { get; set; }

    [MaxLength(15, ErrorMessage = "El número de caracteres debe ser menor a 15")]
    public string Phone { get; set; }
}