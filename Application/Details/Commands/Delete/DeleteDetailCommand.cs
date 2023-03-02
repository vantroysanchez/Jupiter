using Application.Common.Exceptions;
using Domain.Interfaces;
using MediatR;

namespace Application.Details.Commands.Delete
{
    public record DeleteDetailCommand(int Id): IRequest<Unit>;

    public class DeleteDetailCommandHandler : IRequestHandler<DeleteDetailCommand, Unit>
    {
        private readonly IDetailService _services;

        public DeleteDetailCommandHandler(IDetailService services)
        {
            _services = services;
        }

        public async Task<Unit> Handle(DeleteDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _services
            .GetById(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Details), request.Id);
            }

            await _services.Remove(entity, cancellationToken);            

            return Unit.Value;
        }
    }
}
