using FluentValidation;
using Infrastructure.Interfaces;

namespace Application.Details.Commands.Create
{
    public class CreateDetailCommandValidator: AbstractValidator<CreateDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateDetailCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");

            RuleFor(q => q.Quantity)
            .NotEmpty()
            .WithMessage("Quantity is required");

            RuleFor(q => q.Amount)
            .NotEmpty()
            .WithMessage("Amount is required and less than 1mm");

            RuleFor(q => q.HeaderId)
            .NotEmpty()
            .WithMessage("Header is required");
        }
    }
}
