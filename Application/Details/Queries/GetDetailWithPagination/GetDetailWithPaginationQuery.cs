using Application.Common.Mappings;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using MediatR;

namespace Application.Details.Queries.GetDetailWithPagination
{
    public record GetDetailWithPaginationQuery: IRequest<PaginatedList<DetailDtoWithPagination>>
    {
        //public int ListId { get; init; }
        public int PageNumber { get; init; } = 1;
        public int PageSize { get; init; } = 10;
    }

    public class GetDetailWithPaginationQueryHandler : IRequestHandler<GetDetailWithPaginationQuery, PaginatedList<DetailDtoWithPagination>>
    {
        private readonly IDetailService _services;
        private readonly IMapper _mapper;

        public GetDetailWithPaginationQueryHandler(IMapper mapper, IDetailService services)
        {
            _mapper = mapper;
            _services = services;
        }

        public async Task<PaginatedList<DetailDtoWithPagination>> Handle(GetDetailWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _services
                .GetAll()
                .OrderBy(x => x.Id & x.HeaderId)
                .ProjectTo<DetailDtoWithPagination>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
