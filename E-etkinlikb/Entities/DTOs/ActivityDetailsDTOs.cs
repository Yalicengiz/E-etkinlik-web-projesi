using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTOs
{
    public class ActivityDetailsDTOs:IDto
    {
        //ActivityName, ActivityTypeName, IsFreeName, DailyPrice
        public int Id { get; set; }
        public int PriceTypeId { get; set; }
        public int ActivityTypeId { get; set; }
        public string ActivityName { get; set; }
        public string ActivityTypeName { get; set; }
        public string PriceTypeName { get; set; }
        public string ActivityLocation { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public int Price { get; set; }
        public int InsertUserId { get; set; }
        public int Capacity { get; set; }
    }
}
