using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Validators.Users
{
    public class DeleteCommandValidator : AbstractValidator<Application.Users.Delete.Command>
    {
        public DeleteCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("آیدی نمی تواند خالی باشد.");
        }
    }
}