using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Details.Queries.GetDetailByHeader
{
    public record GetDetailByHeaderQuery(int HeaderId) : IRequest<DetailByHeaderVm>;

    public class GetDetailByHeaderQueryHandler: IRequestHandler<GetDetailByHeaderQuery, DetailByHeaderVm>
    {
        private readonly IDetailService _services;
        private readonly IMapper _mapper;

        public GetDetailByHeaderQueryHandler(IMapper mapper, IDetailService services)
        {
            _mapper = mapper;
            _services = services;
        }

        public async Task<DetailByHeaderVm> Handle(GetDetailByHeaderQuery request, CancellationToken cancellationToken)
        {
            return new DetailByHeaderVm
            {
                Lists = await _services
                .GetAll()
                .ProjectTo<DetailDtoByHeader>(_mapper.ConfigurationProvider)
                .Where(x => x.HeaderId == request.HeaderId)
                .ToListAsync(cancellationToken)
            };                
        }
    }


}
