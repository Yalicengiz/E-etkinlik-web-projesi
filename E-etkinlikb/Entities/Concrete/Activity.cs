using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Activity:IEntity
    {
        public int Id { get; set; }
        public int ActivityTypeId { get; set; }
        public int PriceTypeId { get; set; }
        public DateTime ActivityDate { get; set; }
        public string Description { get; set; }
        public string ActivityLocation { get; set; }

        public int Price { get; set; }
        public string ActivityName { get; set; }
       
       public int InsertUserId { get; set; }
        public int Capacity { get; set; }
     
       
    }
}
