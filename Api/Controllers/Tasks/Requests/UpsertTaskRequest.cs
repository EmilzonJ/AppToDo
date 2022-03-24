using System.ComponentModel.DataAnnotations;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Api.Controllers.Tasks.Requests;

public class UpsertTaskRequest
{
    [Required(ErrorMessage = "Este campo es requerido")]
    public string Name { get; set; }

    [MaxLength(100, ErrorMessage = "El número de caracteres debe ser menor a 100")]
    public string Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public TaskStatus Status { get; set; }

    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}