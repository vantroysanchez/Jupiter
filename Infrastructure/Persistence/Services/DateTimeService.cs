using Infrastructure.Interfaces;

namespace Infrastructure.Persistence.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
