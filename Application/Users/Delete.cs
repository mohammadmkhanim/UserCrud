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
    public class Delete
    {
        public class Command : IRequest<Result<UserDto>>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<UserDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly IValidator<Command> _createCommandValidator;

            public Handler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<Command> createCommandValidator)
            {
                _createCommandValidator = createCommandValidator;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Result<UserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var validationResult = _createCommandValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    return Result<UserDto>.Failure((int)HttpStatusCode.BadRequest, validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }
                var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);
                if (user == null)
                {
                    return Result<UserDto>.Failure((int)HttpStatusCode.NotFound, new List<string> { "کاربر وجود ندارد." });
                }
                await _unitOfWork.UserRepository.DeleteAsync(user.Id);
                if (await _unitOfWork.SaveChangesAsync() > 0)
                {
                    var userDto = _mapper.Map<UserDto>(user);
                    return Result<UserDto>.Success((int)HttpStatusCode.OK, userDto);
                }
                else
                {
                    return Result<UserDto>.Failure((int)HttpStatusCode.InternalServerError, new List<string> { "عملیات با خطا مواجه شد." });
                }
            }
        }
    }
}

