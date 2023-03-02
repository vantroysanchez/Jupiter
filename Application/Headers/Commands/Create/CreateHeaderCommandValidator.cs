using FluentValidation;
using Infrastructure.Interfaces;

namespace Application.Headers.Commands.Create
{
    public class CreateHeaderCommandValidator: AbstractValidator<CreateHeaderCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateHeaderCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");            
        }
    }
}
