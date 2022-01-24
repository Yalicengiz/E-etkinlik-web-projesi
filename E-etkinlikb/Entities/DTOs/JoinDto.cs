using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class JoinDto
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string ActivityName { get; set; }
        public int CustomerId { get; set; }
        public DateTime JoinDate { get; set; }
        public int ReturnDate { get; set; }
    }
}
