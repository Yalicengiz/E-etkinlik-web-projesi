using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework.Abstract;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IActivityService:IService<Activity>
    {
        IDataResult<List<ActivityDetailsDTOs>> GetActivitysByActivityTypeId(int id);
        IDataResult<List<Activity>> GetActivityDetailsByActivityId(int carId);
        IDataResult<List<ActivityDetailsDTOs>> GetActivitysByIsFreeId(int id);
        IDataResult<List<ActivityDetailsDTOs>> GetActivityDetails();

    }
}
