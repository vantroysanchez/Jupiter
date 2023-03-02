using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Header> Headers { get; }

        DbSet<Detail> Details { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
