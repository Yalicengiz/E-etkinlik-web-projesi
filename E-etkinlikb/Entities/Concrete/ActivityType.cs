using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;


namespace Entities.Concrete
{
    public class ActivityType:IEntity
    {
        public int ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
    }
}
