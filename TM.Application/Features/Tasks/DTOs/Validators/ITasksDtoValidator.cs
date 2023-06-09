using FluentValidation;

namespace TM.Application.Features.Tasks.DTOs.Validators
{
    public class ITasksDtoValidator : AbstractValidator<ITasksDto>
    {
        public ITasksDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Description)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull()
               .MaximumLength(200).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.StartDate)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .LessThanOrEqualTo(p => p.EndDate).WithMessage("{PropertyName} must be less than or equal to {ComparisonValue}.");

            RuleFor(p => p.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThanOrEqualTo(p => p.StartDate).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");


        }
    }
}