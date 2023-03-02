using Infrastructure.Interfaces;
using MediatR;

namespace Application.Account.Command.Create
{
    public record CreateAccountCommand: IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, string>
    {
        private readonly IIdentityService _identityService;

        public CreateAccountCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.CreateUserAsync(request.UserName, request.Password);
            
        }
    }
}
