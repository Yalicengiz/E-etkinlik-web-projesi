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
using DataAccess.Concrete.EntityFramework.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class IsFreeManager : IPriceType
    {
        private IIsFreeDal _IsFreeDal;

        public IsFreeManager(IIsFreeDal IsFreeDal)
        {
            _IsFreeDal = IsFreeDal;
        }
        //[ValidationAspect(typeof(PriceTypeValidator))]
        public IResult Add(PriceType IsFree)
        {
            _IsFreeDal.Add(IsFree);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(PriceType IsFree)
        {
            _IsFreeDal.Delete(IsFree);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<PriceType>> GetAll()
        {
            return new SuccessDataResult<List<PriceType>>(_IsFreeDal.GetAll().ToList(), Messages.Listed);
        }

        public IDataResult<List<PriceType>> GetById(int id)
        {
            return new SuccessDataResult<List<PriceType>>(_IsFreeDal.GetAll(p => p.PriceTypeId== id).ToList(), Messages.Listed);
        }

        public IResult Update(PriceType IsFree)
        {
            _IsFreeDal.Update(IsFree);
            return new SuccessResult(Messages.Updated);
        }
    }
}