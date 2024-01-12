using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Headers.Queries.GetOnly
{
    public record GetOnlyHeaderQuery: IRequest<List<HeaderOnlyDto>>;

    public class GetOnlyHeaderQueryHandler(IMapper mapper, IHeaderService services)
        : IRequestHandler<GetOnlyHeaderQuery, List<HeaderOnlyDto>>
    {
        public async Task<List<HeaderOnlyDto>> Handle(GetOnlyHeaderQuery request, CancellationToken cancellationToken)
        {
            var header = await services
                .GetAllAsync();

            return mapper.Map<List<HeaderOnlyDto>>(header);
        }
    }

}
