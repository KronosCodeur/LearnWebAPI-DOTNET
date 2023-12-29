using System.ComponentModel.DataAnnotations;

namespace LearnWebAPI_DOTNET.Models;

public class Task
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Done { get; set; }
}