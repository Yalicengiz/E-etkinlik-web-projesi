using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserOperationClaimService : IUserOperationService
    {
        private IUserOperationClaimDal _JoinDal;
        public UserOperationClaimService(IUserOperationClaimDal JoinDal)
        {
            _JoinDal = JoinDal;
        }
        //[ValidationAspect(typeof(JoinValidator))]
        public IResult Add(UserOperationClaim Join)
        {
            _JoinDal.Add(Join);
            return new SuccessResult("Etkinliğe katıldı");

        }

        public IResult Delete(UserOperationClaim Join)
        {
            _JoinDal.Delete(Join);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_JoinDal.GetAll().ToList(), Messages.Listed);
        }

        public IDataResult<List<UserOperationClaim>> GetById(int id)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_JoinDal.GetAll(p => p.Id == id).ToList(), Messages.Listed);
        }

        public IResult Update(UserOperationClaim Join)
        {
            _JoinDal.Update(Join);
            return new SuccessResult(Messages.Updated);
        }
    }
}
