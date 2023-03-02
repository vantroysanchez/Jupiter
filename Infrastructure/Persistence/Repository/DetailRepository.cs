using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repository
{
    class DetailRepository: BaseRepository<Detail>, IDetailRepository
    {
        public DetailRepository(ApplicationDbContext context) : base(context) { }
    }
}
