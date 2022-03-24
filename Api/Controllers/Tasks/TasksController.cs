﻿using Api.Controllers.Tasks.Requests;
using Api.Controllers.Tasks.Responses;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Task = Domain.Entities.Task;
using TaskStatus = Domain.Enums.TaskStatus;

namespace Api.Controllers.Tasks;

[ApiController]
[Route("api/[controller]/[action]")]
public class TasksController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public TasksController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AllTaskResponse>>> GetAll()
    {
        var tasks = await _unitOfWork.Tasks.GetAllAsync();
        
        var response = tasks.Select(task => new AllTaskResponse
        {
            Id = task.Id,
            Name = task.Description,
            Description = task.Description,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            Status = task.Status
        }).ToList();

        return Ok(response);
    }

    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<IEnumerable<AllTaskResponse>>> GetAllByUser(Guid userId)
    {
        var tasks = await _unitOfWork.Tasks.GetAllByUser(userId);

        var response = tasks.Select(task => new AllTaskResponse
        {
            Id = task.Id,
            Name = task.Description,
            Description = task.Description,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            Status = task.Status
        }).ToList();

        return Ok(response);
    }
    
    [HttpGet("{categoryId:guid}")]
    public async Task<ActionResult<IEnumerable<AllTaskResponse>>> GetAllByCategory(Guid categoryId)
    {
        var tasks = await _unitOfWork.Tasks.GetAllByCategory(categoryId);

        var response = tasks.Select(task => new AllTaskResponse
        {
            Id = task.Id,
            Name = task.Description,
            Description = task.Description,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            Status = task.Status
        }).ToList();

        return Ok(response);
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AllTaskResponse>>> GetAllByStatus([FromQuery] TaskStatus status)
    {
        var tasks = await _unitOfWork.Tasks.GetAllByStatus(status);

        var response = tasks.Select(task => new AllTaskResponse
        {
            Id = task.Id,
            Name = task.Description,
            Description = task.Description,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            Status = task.Status
        }).ToList();

        return Ok(response);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskResponse>> GetById(Guid id)
    {
        var task = await _unitOfWork.Tasks.GetByIdAsync(id);

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
            },
            User = new TaskUserResponse
            {
                Id = task.User.Id,
                UserName = task.User.UserName,
                Email = task.User.Email,
                Phone = task.User.Phone
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
            CategoryId = request.CategoryId,
            UserId = request.UserId
        };

        await _unitOfWork.Tasks.AddAsync(task);

        return task.Id;
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpsertTaskRequest request)
    {
        var task = await _unitOfWork.Tasks.GetByIdAsync(id);

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
        task.UserId = request.UserId;

        await _unitOfWork.Tasks.UpdateAsync(task);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var task = await _unitOfWork.Tasks.GetByIdAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        await _unitOfWork.Tasks.RemoveAsync(task);

        return NoContent();
    }
}