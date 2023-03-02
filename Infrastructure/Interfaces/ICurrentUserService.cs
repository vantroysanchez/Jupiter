using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? Email { get;  }
        string? Roles { get; }
    }
}
