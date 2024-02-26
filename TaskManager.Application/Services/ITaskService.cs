using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManager.Application.Services;

public interface ITaskService
{
    Task<IEnumerable<Task>> GetAllTasks();
    Task<Task> GetTaskById(int id);
    Task CreateTask(Task task);
    Task UpdateTask(Task task);
    Task DeleteTask(int id);
}