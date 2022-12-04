using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingApp.Models.Validators
{
    public class CreateCandidateDtoValidator : AbstractValidator<CreateCandidateDto>
    {
        public CreateCandidateDtoValidator()
        {
            RuleFor(c => c.Name)
                .MaximumLength(50)
                .NotEmpty();
        }
    }
}
