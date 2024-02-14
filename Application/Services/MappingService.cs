using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
namespace Application.Services
{
    public class MappingService : Profile
    {
        public MappingService()
        {
            CreateMap<User, Dtos.Users.UserDto>().ReverseMap();
            CreateMap<User, Application.Users.Create.Command>().ReverseMap();
            CreateMap<User, Application.Users.Edit.Command>().ReverseMap();
        }
    }
}