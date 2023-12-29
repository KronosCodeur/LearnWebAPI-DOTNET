using Microsoft.EntityFrameworkCore;
using Task = LearnWebAPI_DOTNET.Models.Task;

namespace LearnWebAPI_DOTNET.Data;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    public DbSet<Task> Tasks { get; set; }
}