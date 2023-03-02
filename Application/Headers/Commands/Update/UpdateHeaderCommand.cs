using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Headers.Commands.Update
{
    public record UpdateHeaderCommand: IRequest<Unit>
    {        
        public int Id { get; set; }
        public string? Description { get; init; }
    }

    public class UpdateHeaderCommandHandler: IRequestHandler<UpdateHeaderCommand, Unit>
    {
        private readonly IHeaderService _services;

        public UpdateHeaderCommandHandler(IHeaderService services)
        {
            _services = services;
        }

        public async Task<Unit> Handle(UpdateHeaderCommand request, CancellationToken cancellationToken)
        {
            var entity = await _services
                .GetById(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Header), request.Id);
            }

            entity.Description = request.Description;

            await _services.Update(entity,cancellationToken);

            return Unit.Value;
        }
    }
}
