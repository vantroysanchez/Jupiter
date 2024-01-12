using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Headers.Queries.GetOnly
{
    public class HeaderOnlyDto : IMapFrom<Header>
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public bool Status { get; set; }
    }
}
