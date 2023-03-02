using Application.Common.Exceptions;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Details.Commands.Update
{
    public record UpdateDetailCommand: IRequest<Unit>
    {
        public int Id { get; init; }
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int HeaderId { get; set; }
    }

    public class UpdateDetailCommandhandler : IRequestHandler<UpdateDetailCommand, Unit>
    {
        private readonly IDetailService _services;

        public UpdateDetailCommandhandler(IDetailService services)
        {
            _services = services;
        }

        public async Task<Unit> Handle(UpdateDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _services
                .GetById(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Detail), request.Id);
            }

            entity.Description = request.Description;
            entity.Quantity = request.Quantity;
            entity.Amount = request.Amount;
            entity.HeaderId = request.HeaderId;

            await _services.Update(entity, cancellationToken);

            return Unit.Value;
        }
    }
}
