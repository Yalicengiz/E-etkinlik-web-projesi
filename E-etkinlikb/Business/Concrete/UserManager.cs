using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IUserOperationClaimDal _opDal;

        public UserManager(IUserDal userDal, IUserOperationClaimDal opDal)
        {
            _userDal = userDal;
            _opDal = opDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll().ToList(), Messages.Listed);
        }

        public IDataResult<List<User>> GetById(int id)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(p => p.Id == id).ToList(), Messages.Listed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<UserOperationClaim> SuperUser(int id)
        {

            var result = _opDal.Get(x => x.UserId == id);
            if (result!=null)
            {
                using (ReCapContext context = new ReCapContext())
                {
                    context.Set<UserOperationClaim>().First(x => x.UserId == id).OperationClaimId = 3;
                    Op(id);
                    context.SaveChanges();
                }
              
                
            }
            else
            {
                return new ErrorDataResult<UserOperationClaim>();
            }

            return new SuccessDataResult<UserOperationClaim>("3");

        }

        public bool Op(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                context.Set<User>().Single(x => x.Id == id).OpId = 3;
                context.SaveChanges();
            };
            return true;
        }
    }
}
