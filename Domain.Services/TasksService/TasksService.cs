using System.Collections.Generic;
using System.Threading.Tasks;
using static ViteNET.React.Infrastructure.Repositories.GenericRepository.IGenericRepository;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using ViteNET.React.Domain.Models.DTOs;
using ViteNET.React.Domain.Models.Models;
using ViteNET.React.Infrastructure.Repositories.TasksRepository;
using ViteNET.React.Infrastructure.Repositories.UserRepository;

public class TasksService : ITasksService
{
    private readonly ITasksRepository _taskRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public TasksService(ITasksRepository taskRepository , IUserRepository userRepository,IMapper mapper)
    {
        _taskRepository = taskRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
    {
       var tasks=  await _taskRepository.GetAllAsync();
       return _mapper.Map<IEnumerable<TaskDto>>(tasks);
    }

    public async Task<TaskDto> GetTaskByIdAsync(int id)
    {
        var  task = await _taskRepository.GetByIdAsync(id);
        return _mapper.Map<TaskDto>(task);
    }
    public async Task<IEnumerable<TaskDto>> GetTasksByUserIdAsync(int id)
    {
        
        var tasks = await _taskRepository.GetTasksByUserIdAsync(id);
        return _mapper.Map<IEnumerable<TaskDto>>(tasks);
    }


    public async Task<TaskDto> AddTaskAsync(CreateTaskDto createTaskDto)
    {
        var task = _mapper.Map<Tasks>(createTaskDto);
        task.CreatedAt = DateTime.UtcNow;
        var user = await _userRepository.GetByIdAsync(task.UserId.Value);
        if(user != null)
        {
            user.Tasks.Add(task);
        } 
       
        var addedTask =await _taskRepository.AddAsync(task);
        return _mapper.Map<TaskDto>(addedTask);
    }

    public async Task<TaskDto> UpdateTaskAsync(UpdateTaskDto updateTaskDto)
    {
        var existingTask = await _taskRepository.GetByIdAsync(updateTaskDto.Id);

        _mapper.Map(updateTaskDto, existingTask);

        await _taskRepository.UpdateAsync(existingTask);

        return _mapper.Map<TaskDto>(existingTask);
    }


    public async Task DeleteTaskAsync(int id)
    {
        await _taskRepository.DeleteAsync(id);
    }
}
