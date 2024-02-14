using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Core;
using Application.Dtos.Users;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructures.Data.UnitOfWorks;
using MediatR;

namespace Application.Users
{
    public class List
    {
        public class Query : IRequest<Result<List<UserDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Result<List<UserDto>>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<List<UserDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var users = await _unitOfWork.UserRepository.GetAllAsync();
                var userDtos = _mapper.Map<List<UserDto>>(users);
                return Result<List<UserDto>>.Success((int)HttpStatusCode.OK, userDtos);
            }
        }
    }
}

