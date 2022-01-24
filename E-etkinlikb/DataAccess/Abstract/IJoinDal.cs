using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IJoinDal:IEntityRepository<Join>
    {
        List<JoinDto> GetJoinsByUserId(int id);
        void DeleteJoin(int id);
    }
}
