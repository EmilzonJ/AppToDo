using Api.Controllers.Tasks.Requests;
using Api.Controllers.Tasks.Responses;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task = Domain.Entities.Task;

namespace Api.Controllers.Tasks;

[ApiController]
[Route("api/[controller]/[action]")]
public class TasksController : ControllerBase
{
    private readonly IRepositoryBase<Task, Guid> _repository;

    public TasksController(IRepositoryBase<Task, Guid> repository)
    {
        _repository = repository;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskResponse>> GetById(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        var response = new TaskResponse
        {
            Id = task.Id,
            Name = task.Description,
            Description = task.Description,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            Status = task.Status,
            Category = new TaskCategoryResponse
            {
                Id = task.Category.Id,
                Name = task.Category.Name
            }
        };

        return response;
    }
    
    [HttpPost]  
    public async Task<ActionResult<Guid>> Create([FromBody] UpsertTaskRequest request)
    {
        var task = new Task
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Status = request.Status,
            CategoryId = request.CategoryId
        };

        await _repository.AddAsync(task);

        return task.Id;
    }
    
    [HttpPut("{id:guid}")] 
    public async Task<ActionResult> Update(Guid id, [FromBody] UpsertTaskRequest request)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        task.Name = request.Name;
        task.Description = request.Description;
        task.StartDate = request.StartDate;
        task.EndDate = request.EndDate;
        task.Status = request.Status;
        task.CategoryId = request.CategoryId;

        await _repository.UpdateAsync(task);

        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        await _repository.RemoveAsync(task);

        return NoContent();
    }

}