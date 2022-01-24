using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ActivityImageManager : IActivityImageService
    {
        private IActivityImageDal _ActivityImageDal;

        public ActivityImageManager(IActivityImageDal ActivityImageDal)
        {
            _ActivityImageDal = ActivityImageDal;
        }

        //[ValidationAspect(typeof(ActivityImageValidator))]
        public IResult Add(IFormFile file, UserImage ActivityImage)
        {
            var result = BusinessRole.Rol(CheckActivityImageCount(ActivityImage.Id), CheckIfActivityImageNull(ActivityImage.Id));
            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Upload(file);
            if(!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            ActivityImage.ImagePath = imageResult.Message;
            ActivityImage.Date = DateTime.Now;
            _ActivityImageDal.Add(ActivityImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(UserImage ActivityImage)
        {
            var image = _ActivityImageDal.Get(p => p.Id == ActivityImage.Id);
            if(image==null)
            {
                return new ErrorResult("Image not found.");
            }

            FileHelper.Delete(image.ImagePath);
            _ActivityImageDal.Delete(ActivityImage);
            return new SuccessResult();
        }

        public IDataResult<List<UserImage>> GetAll()
        {
            return new SuccessDataResult<List<UserImage>>(_ActivityImageDal.GetAll().ToList(), Messages.Listed);
        }

        public IDataResult<List<UserImage>> GetById(int id)
        {
            return new SuccessDataResult<List<UserImage>>(_ActivityImageDal.GetAll(p => p.Id == id).ToList(),
                Messages.Listed);
        }

        public IResult Update(IFormFile file, UserImage ActivityImage)
        {
            var result = _ActivityImageDal.Get(p => p.Id == ActivityImage.Id);
            if (result == null)
            {
                return new ErrorResult("Image not found!");
            }

            var uploadImage = FileHelper.Update(file, result.ImagePath);
            if(!uploadImage.Success)
            {
                return new ErrorResult(uploadImage.Message);
            }

            ActivityImage.ImagePath = uploadImage.Message;
            ActivityImage.Date=DateTime.Now;
            _ActivityImageDal.Update(ActivityImage);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckActivityImageCount(int ActivityId)
        {
            var result = _ActivityImageDal.GetAll(p => p.Id ==ActivityId).Count;
            if (result >= 5)
            {
                return new ErrorResult("Etkinliğin en fazla 5 resmi olabilir.");
            }

            return new SuccessResult();
        }
        private IDataResult<List<UserImage>> CheckIfActivityImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _ActivityImageDal.GetAll(c => c.Id == id).Any();
                if (!result)
                {
                    List<UserImage> Activityimage = new List<UserImage>();
                    Activityimage.Add(new UserImage { Id = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<UserImage>>(Activityimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<UserImage>>(exception.Message);
            }

            return new SuccessDataResult<List<UserImage>>(_ActivityImageDal.GetAll(p => p.Id == id).ToList());
        }
    }
}
