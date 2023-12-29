using AutoMapper;
using LearnWebAPI_DOTNET.Entities;
using Task = LearnWebAPI_DOTNET.Models.Task;

namespace LearnWebAPI_DOTNET.helpers;

public class TaskMapping : Profile
{
    public TaskMapping()
    {
        CreateMap<Task, TaskEntityCreate>().ReverseMap();
        CreateMap<Task, TaskEntityUpdate>().ReverseMap();
    }
}