using System.ComponentModel.DataAnnotations;

namespace Api.Controllers.Categories.Requests
{
    public class UpsertCategoryRequest
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [MaxLength(50, ErrorMessage = "El número de caracteres debe ser menor a 50")]

        public string Name { get; set; }
    }
}
