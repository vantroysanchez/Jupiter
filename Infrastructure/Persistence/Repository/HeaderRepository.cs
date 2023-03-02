using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository
{
    class HeaderRepository: BaseRepository<Header>, IHeaderRepository
    {
        public HeaderRepository(ApplicationDbContext context): base(context) { }
    }
}
