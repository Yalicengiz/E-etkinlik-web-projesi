using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class JoinManager : IJoinService
    {
        private IJoinDal _JoinDal;
        private IActivityDal _activityDal;
        public JoinManager(IJoinDal JoinDal,IActivityDal activityDal)
        {
            _JoinDal = JoinDal;
            _activityDal = activityDal;
        }
        //[ValidationAspect(typeof(JoinValidator))]
        public IResult Add(Join Join)
        {
            if (_activityDal.Get(x => x.Id == Join.ActivityId).Capacity > 0)
            {
                _JoinDal.Add(Join);
                _activityDal.CapacityCount(Join.ActivityId);
                return new SuccessResult("Etkinliğe katıldı");
            }
            return new SuccessResult("Bu etkinlikte yer kalmamıştır.");
            
               
             
          
        }

        public IResult Delete(Join Join)
        {

            _JoinDal.Delete(Join);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult DeleteJoin(int id)
        {
           var acId= _JoinDal.Get(p => p.Id==id).ActivityId;
            _JoinDal.DeleteJoin(id);
            _activityDal.CapacityCountPlus(acId);
            return new SuccessResult("silindi");
        }

        public IDataResult<List<Join>> GetAll()
        {
            return new SuccessDataResult<List<Join>>(_JoinDal.GetAll().ToList(),Messages.Listed);
        }

        public IDataResult<List<Join>> GetById(int id)
        {
            return new SuccessDataResult<List<Join>>(_JoinDal.GetAll(p => p.Id == id).ToList(), Messages.Listed);
        }

        public IDataResult<Join> GetJoinUserAndActivityId(int usId, int actId)
        {
            return new SuccessDataResult<Join>(_JoinDal.Get(p => p.CustomerId==usId && p.ActivityId==actId), Messages.Listed);
        }

        public IDataResult<List<JoinDto>> GetJoinUserId(int id)
        {
            return new SuccessDataResult<List<JoinDto>>(_JoinDal.GetJoinsByUserId(id).ToList());
        }

        public IResult Update(Join Join)
        {
            _JoinDal.Update(Join);
            return new SuccessResult(Messages.Updated);
        }
    }
}
