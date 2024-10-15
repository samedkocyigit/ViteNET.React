﻿using AutoMapper;
using ViteNET.React.Domain.Models.DTOs;
using ViteNET.React.Domain.Models.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserRegisterDto, User>()
            .ForMember(dest => dest.Password, opt => opt.Ignore());
        CreateMap<CreateTaskDto, Tasks>(); 
        CreateMap<Tasks, TaskDto>();    
        CreateMap<UpdateTaskDto, Tasks>();
        CreateMap<Task, UpdateTaskDto>();
    }
}
