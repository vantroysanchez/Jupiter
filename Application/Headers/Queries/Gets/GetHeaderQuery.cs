using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Headers.Queries.Gets
{
    public record GetHeaderQuery: IRequest<HeaderVm>;

    
    public class GetHeaderQueryHandler: IRequestHandler<GetHeaderQuery, HeaderVm>
    {
        private readonly IHeaderService _services;
        private readonly IMapper _mapper;

        public GetHeaderQueryHandler(IMapper mapper, IHeaderService services)
        {
            _mapper = mapper;
            _services = services;
        }

        public async Task<HeaderVm> Handle(GetHeaderQuery request, CancellationToken cancellationToken)
        {
            return new HeaderVm
            {
                Lists = await _services
                .GetAll()
                .ProjectTo<HeaderDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Code)                
                .ToListAsync(cancellationToken)
            };
        }
    }
    

}
