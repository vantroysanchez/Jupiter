using Domain.Entities;
using Domain.Events.HeaderEvents;
using Domain.Interfaces;
using MediatR;

namespace Application.Headers.Commands.Create
{
    public record CreateHeaderCommand: IRequest<int>
    {
        public string? Description { get; set; }
    }

    public class CreateHeaderCommandHandler: IRequestHandler<CreateHeaderCommand, int>
    {
        private readonly IHeaderService _services;

        public CreateHeaderCommandHandler(IHeaderService services)
        {
            _services = services;
        }

        public async Task<int> Handle(CreateHeaderCommand request, CancellationToken cancellationToken)
        {
            Random random = new Random();
            var code = string.Join("8",random.Next(100, 999), random.Next(10, 99));
            var entity = new Header();

            entity.Code = Convert.ToInt32(code);
            entity.Description = request.Description;
            entity.Date = DateTime.Now;
            entity.Status = true;

            entity.AddDomainEvent(new HeaderCreatedEvent(entity));
                        
            await _services.Add(entity, cancellationToken);

            return entity.Id;
        }
    }
}
