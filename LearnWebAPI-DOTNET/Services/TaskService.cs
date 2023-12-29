using LearnWebAPI_DOTNET.Data;
using LearnWebAPI_DOTNET.Repositories;
using Microsoft.EntityFrameworkCore;
using Task = LearnWebAPI_DOTNET.Models.Task;

namespace LearnWebAPI_DOTNET.Services;

public class TaskService : TaskRepository
{
    private readonly TaskDbContext _dbContext;

    public TaskService(TaskDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> CreateTask(Task task)
    {
        task.Done = false;
        _dbContext.Tasks.Add(task);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Task?> GetOneTask(int id)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task is null)
        {
            return null;
        }
        return task;
    }

    public async Task<List<Task>> GetAllTasks()
    {
        var tasks = await _dbContext.Tasks.ToListAsync();
        return tasks;
    }

    public async Task<bool> DeleteTask(int id)
    {
        var task = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
        if (task is not null)
        {
            _dbContext.Tasks.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Task?> UpdateTask(Task task)
    {
        var oldTask = await _dbContext.Tasks.FirstOrDefaultAsync(t => t.Id == task.Id);
        if (oldTask is not null)
        {
            oldTask.Title = task.Title;
            oldTask.Description = task.Description;
            oldTask.Done = task.Done;
            await _dbContext.SaveChangesAsync();
            return oldTask;
        }

        return null;
    }
}