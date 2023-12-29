using AutoMapper;
using LearnWebAPI_DOTNET.Entities;
using LearnWebAPI_DOTNET.Repositories;
using LearnWebAPI_DOTNET.Services;
using Microsoft.AspNetCore.Mvc;
using Task = LearnWebAPI_DOTNET.Models.Task;

namespace LearnWebAPI_DOTNET.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskService _taskService;
    private readonly IMapper _mapper;

    public TaskController(TaskService taskService, IMapper mapper)
    {
        _taskService = taskService;
        _mapper = mapper;
    }

    [HttpGet("GetAllTasks")]
    public async Task<ActionResult<List<Task>>> GetAllTasks()
    {
        var tasks = await _taskService.GetAllTasks();
        return Ok(tasks);
    }

    [HttpDelete("DeleteTask/{id}")]
    public async Task<ActionResult<Task>> DeleteTask(int id)
    {
        var result = await _taskService.DeleteTask(id);
        if (result)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpGet("GetOneTask/{id}")]
    public async Task<ActionResult<Task>> GetOneTask(int id)
    {
        var task = await _taskService.GetOneTask(id);
        if (task is null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost("UpdateTask/{id}")]
    public async Task<ActionResult<Task>> UpdateTask(TaskEntityUpdate taskEntityUpdate)
    {
        var newTask = _mapper.Map<Task>(taskEntityUpdate);
        var task = await _taskService.UpdateTask(newTask);
        if (task is null)
        {
            return NotFound();
        }
        return Ok(task);
    }

    [HttpPost("SaveTask")]
    public async Task<ActionResult<Task>> SaveTask(TaskEntityCreate taskEntityCreate)
    {
        try
        {
            var task = _mapper.Map<Task>(taskEntityCreate);
            await _taskService.CreateTask(task);
            return StatusCode(201, task);
        }
        catch (Exception e)
        {
            return StatusCode(500, "erreur" + e);
        }
    }
}