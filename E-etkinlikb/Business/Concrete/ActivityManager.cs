using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ActivityManager : IActivityService
    {
        private IActivityDal _ActivityDal;

        public ActivityManager(IActivityDal ActivityDal)
        {
            _ActivityDal = ActivityDal;
        }
        //[SecuredOperation("product.add,admin")]
        //[ValidationAspect(typeof(ActivityValidator))]
       
        public IResult Add(Activity Activity)
        {
          
            _ActivityDal.Add(Activity);
            return new SuccessResult(Messages.Added);
               
        }

        public IResult Delete(Activity Activity)
        {
            _ActivityDal.Delete(Activity);
            return new SuccessResult(Messages.Deleted);
        }
        
        public IDataResult<List<Activity>> GetAll()
        {
            return new SuccessDataResult<List<Activity>>(_ActivityDal.GetAll().ToList(), Messages.Listed);
        }
        
        public IDataResult<List<Activity>> GetById(int id)
        {
            return new SuccessDataResult<List<Activity>>(_ActivityDal.GetAll(p => p.Id == id).ToList(), Messages.Listed);
        }

        public IDataResult<List<ActivityDetailsDTOs>> GetActivityDetails()
        {
            _ActivityDal.GetActivityDetails();
            return new SuccessDataResult<List<ActivityDetailsDTOs>>(_ActivityDal.GetActivityDetails(), "Etkinlik detayları:");
        }

        public IDataResult<List<ActivityDetailsDTOs>> GetActivitysByActivityTypeId(int id)
        {
            return new SuccessDataResult<List<ActivityDetailsDTOs>>(_ActivityDal.GetActivitysByActivityTypeId(id), "Etkinlikler Etkinlik türüne göre Listelendi");
        }

        public IDataResult<List<ActivityDetailsDTOs>> GetActivitysByIsFreeId(int id)
        {
            return new SuccessDataResult<List<ActivityDetailsDTOs>>(_ActivityDal.GetActivitysByActivityTypeId(id), "Etkinlikler Fiyata göre listelendi");
        }
        public IResult Update(Activity Activity)
        {
            _ActivityDal.Update(Activity);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Activity>> GetActivityDetailsByActivityId(int activityId)
        {
            return new SuccessDataResult<List<Activity>>(_ActivityDal.GetActivitysByActivityId(activityId), "Etkinlikler fiyat Türüne göre listelendi");
        }

    }
}
