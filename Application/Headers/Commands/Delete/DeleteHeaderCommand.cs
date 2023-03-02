using Application.Common.Exceptions;
using Domain.Events.HeaderEvents;
using Domain.Interfaces;
using MediatR;

namespace Application.Headers.Commands.Delete
{
    public record DeleteHeaderCommand(int Id) : IRequest<Unit>;

    public class DeleteHeaderCommandHandler : IRequestHandler<DeleteHeaderCommand, Unit>
    {
        private readonly IHeaderService _services;

        public DeleteHeaderCommandHandler(IHeaderService services)
        {
            _services = services;
        }

        public async Task<Unit> Handle(DeleteHeaderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _services
            .GetById(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Headers), request.Id);
            }

            await _services.Remove(entity, cancellationToken);

            entity.RemoveDomainEvent(new HeaderDeletedEvent(entity));            

            return Unit.Value;
        }
    }
}
