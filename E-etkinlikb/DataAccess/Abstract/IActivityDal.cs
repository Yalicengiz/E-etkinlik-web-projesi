using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IActivityDal:IEntityRepository<Activity>
    {
        List<ActivityDetailsDTOs> GetActivitysByActivityTypeId(int id);
        List<Activity> GetActivitysByActivityId(int id);
        List<ActivityDetailsDTOs> GetActivitysByPriceTypeId(int id);
        List<ActivityDetailsDTOs> GetActivityDetails();
        Boolean CapacityCount(int id);
        Boolean CapacityCountPlus(int id);
    }
}
