using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Data;

namespace TaskManager.Application.Services;

public class TaskService: ITaskService
{
    private readonly ApplicationDbContext _context;
    
    public TaskService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Task>> GetAllTasks()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Task> GetTaskById(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task CreateTask(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTask(Task task)
    {
        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}