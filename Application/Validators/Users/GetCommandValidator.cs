using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Validators.Users
{
    public class GetCommandValidator : AbstractValidator<Application.Users.Get.Query>
    {
        public GetCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("آیدی نمی تواند خالی باشد.");
        }
    }
}