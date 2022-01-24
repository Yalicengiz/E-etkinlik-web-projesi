using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IJoinService:IService<Join>
    {
        IDataResult<List<JoinDto>> GetJoinUserId(int id);
        IResult DeleteJoin(int id);
        IDataResult<Join> GetJoinUserAndActivityId(int usId,int actId);
    }
}
