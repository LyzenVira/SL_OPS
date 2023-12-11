using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperLandscapes_Blog.Application.Features.Authors.Commands.InsertAuthor
{
    public class InsertAuthorValidator : AbstractValidator<InsertAuthorCommand>
    {
        public InsertAuthorValidator()
        {
            RuleFor(x => x.Fullname)
                .NotEmpty().WithMessage("Fullname is required.")
                .MaximumLength(50).WithMessage("Fullname must not exceed 50 characters.");

            RuleFor(x => x.Employment)
                .NotEmpty().WithMessage("Employment is required.")
                .MaximumLength(50).WithMessage("Employment must not exceed 50 characters.");

            RuleFor(x => x.Avatar)
                .NotEmpty().WithMessage("Avatar is required.");

            RuleFor(x => x.LinkedIn)
                .NotEmpty().WithMessage("LinkedIn is required.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.");
        }
    }
}
