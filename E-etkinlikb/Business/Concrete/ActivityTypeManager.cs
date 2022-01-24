using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ActivityTypeManager : IActivityTypeService
    {
        private IActivityTypeDal _ActivityTypeDal;
        public ActivityTypeManager(IActivityTypeDal ActivityTypeDal)
        {
            _ActivityTypeDal = ActivityTypeDal;
        }
        //[ValidationAspect(typeof(ActivityTypeValidator))]
        public IResult Add(ActivityType ActivityType)
        {
            ValidationTool.Validate(new ActivityTypeValidator(),ActivityType);
            _ActivityTypeDal.Add(ActivityType);
            return new SuccessResult("Fiyat eklendi");
        }

        public IResult Delete(ActivityType ActivityType)
        {
            _ActivityTypeDal.Delete(ActivityType);
            return new SuccessResult("Fiyat silindi.");
        }

        public IDataResult<List<ActivityType>> GetAll()
        {
            return new SuccessDataResult<List<ActivityType>>(_ActivityTypeDal.GetAll().ToList(), "Listelendi");
        }

        public IDataResult<List<ActivityType>> GetById(int id)
        {
            return new SuccessDataResult<List<ActivityType>>(_ActivityTypeDal.GetAll(p => p.ActivityTypeId == id), "Listelendi");
        }

        public IResult Update(ActivityType ActivityType)
        {
            _ActivityTypeDal.Update(ActivityType);
            return new SuccessResult("Gündellendi");
        }
    }
}

