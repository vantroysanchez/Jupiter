using Domain.Entities;
using Domain.Events.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Details.Commands.Create
{
    public record CreateDetailCommand: IRequest<int>
    {
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int HeaderId { get; set; }
    }

    public class CreateDetailCommandHandler : IRequestHandler<CreateDetailCommand, int>
    {
        private readonly IDetailService _services;

        public CreateDetailCommandHandler(IDetailService services)
        {
            _services = services;
        }

        public async Task<int> Handle(CreateDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = new Detail();

            entity.Description = request.Description;
            entity.Quantity = request.Quantity;
            entity.Amount = request.Amount;
            entity.HeaderId = request.HeaderId;

            entity.AddDomainEvent(new EntityCreatedEvent<Detail>(entity));

            await _services.Add(entity, cancellationToken);

            return entity.Id;
        }
    }
}
