using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Join:IEntity
    {
        public int Id  { get; set; }
        public int ActivityId  { get; set; }
        public int CustomerId  { get; set; }
        public DateTime JoinDate  { get; set; }
        public int ReturnDate  { get; set; }
    }
}
