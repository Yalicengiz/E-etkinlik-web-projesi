using System;
using Core.Entities.Concrete;
using System.Collections.Generic;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService:IService<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<UserOperationClaim> SuperUser(int id);
        Boolean Op(int id);
    }
}