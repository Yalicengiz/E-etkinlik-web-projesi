using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IActivityImageService
    {
        IDataResult<List<UserImage>> GetById(int id);
        IDataResult<List<UserImage>> GetAll();
        IResult Add(IFormFile file,UserImage ActivityImage);
        IResult Update(IFormFile file, UserImage ActivityImage);
        IResult Delete(UserImage ActivityImage);
    }
}
