using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.Validators.Users
{
    public class EditCommandValidator : AbstractValidator<Application.Users.Edit.Command>
    {
        public EditCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("آیدی نمی تواند خالی باشد.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
                                .MaximumLength(40).WithMessage("نام حداکثر می تواند 40 کاراکتر باشد.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("ایمیل نمی تواند خالی باشد.")
                                .EmailAddress().WithMessage("ایمیل اشتباه وارد شده است.");
        }
    }
}