using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Headers.Queries.GetOnly
{
    public record GetOnlyHeaderQuery: IRequest<List<HeaderOnlyDto>>;

    public class GetOnlyHeaderQueryHandler : IRequestHandler<GetOnlyHeaderQuery, List<HeaderOnlyDto>>
    {
        private readonly IHeaderService _services;
        private readonly IMapper _mapper;

        public GetOnlyHeaderQueryHandler(IMapper mapper, IHeaderService services)
        {            
            _mapper = mapper;
            _services = services;
        }

        public async Task<List<HeaderOnlyDto>> Handle(GetOnlyHeaderQuery request, CancellationToken cancellationToken)
        {
            var response = await _services
                .GetAll()                
                .ProjectTo<HeaderOnlyDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Code)
                .ToListAsync(cancellationToken);

            return response;
        }
    }

}
