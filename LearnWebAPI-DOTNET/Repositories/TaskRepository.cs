using Task = LearnWebAPI_DOTNET.Models.Task;

namespace LearnWebAPI_DOTNET.Repositories;

public interface TaskRepository
{
    Task<bool> CreateTask(Task task);
    Task<Task?> GetOneTask(int id);
    Task<List<Task>> GetAllTasks();
    Task<bool> DeleteTask(int id);
    Task<Task?> UpdateTask(Task task);
}