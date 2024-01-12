using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Headers.Queries.Gets
{
    public record GetHeaderQuery: IRequest<HeaderVm>;

    
    public class GetHeaderQueryHandler(IMapper mapper, IHeaderService services)
        : IRequestHandler<GetHeaderQuery, HeaderVm>
    {
        public async Task<HeaderVm> Handle(GetHeaderQuery request, CancellationToken cancellationToken)
        {
            return new HeaderVm
            {
                Lists = await services
                .GetAll()
                .ProjectTo<HeaderDto>(mapper.ConfigurationProvider)
                .OrderBy(t => t.Code)                
                .ToListAsync(cancellationToken)
            };
        }
    }
    

}
