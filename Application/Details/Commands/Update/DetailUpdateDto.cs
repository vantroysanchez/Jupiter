using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Details.Commands.Update
{
    public class DetailUpdateDto
    {
        public string? Description { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public int HeaderId { get; set; }
    }
}
