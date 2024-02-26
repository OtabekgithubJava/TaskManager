using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Services;

namespace TaskManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksControllers : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksControllers(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
    {
        var tasks = await _taskService.GetAllTasks();
        return Ok(tasks);
    }
    

    [HttpGet("{id}")]
    public async Task<ActionResult<Task>> GetTask(int id)
    {
        var task = await _taskService.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }
        return Ok(task);
    }


    [HttpPost]
    public async Task<ActionResult<Task>> CreateTask(Task task)
    {
        await _taskService.CreateTask(task);
        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, Task task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        await _taskService.UpdateTask(task);
        return NoContent();
    }


    [HttpDelete]
    public async Task<IActionResult> DeleteTask(int id)
    {
        await _taskService.DeleteTask(id);
        return NoContent();
    }
    
}