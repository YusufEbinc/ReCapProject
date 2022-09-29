using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImageDal;
        readonly IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;

        }

        [ValidationAspectAttribute(typeof(CarImageValidator))]
        public IResult Add(List<IFormFile> formFile, CarImage carImage)
        {
            var result = CheckIfImageCount(formFile);

            if (!result)
            {
                return new ErrorResult("en fazla 5 adet resim eklenebilir");
            }

            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.imagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccesResult("işlem başarılı");
        }

        public IResult Delete(CarImage carImage)
        {

            if (carImage.ImageId == 0)
            {
                return new ErrorResult("carImage sıfırdan farklı olmalı");
            }

            _fileHelper.Delete(carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccesResult("başarılı işlem");

        }

        public IResult Update(List<IFormFile> file, CarImage carImage)
        {
            if (carImage.CarId.Equals(null))
            {
                return new ErrorResult("hatalı işlem");
            }
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.imagesPath + carImage.ImagePath, PathConstants.imagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccesResult("işlem başarılı");
        }

        public IDataResult<CarImage> Get(int id)
        {
            var result = _carImageDal.Get(i => i.ImageId == id);

            if (string.IsNullOrEmpty(result.ImagePath))
            {
                result.ImagePath = PathConstants.logoImage;
            }
            result.ImagePath = PathConstants.Path + result.ImagePath;
            return new SuccesDataResult<CarImage>(result);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
           var result = _carImageDal.GetAll();

            foreach (var item in result)
            {
                if (string.IsNullOrEmpty(item.ImagePath))
                {
                    item.ImagePath = PathConstants.logoImage;
                }
                item.ImagePath = PathConstants.Path + item.ImagePath;
            }

            return new SuccesDataResult<List<CarImage>>(result);
        }

        private bool CheckIfImageCount(List<IFormFile> file)
        {
            if (file.Count > 5)
            {
                return false;
            }
            return true;
        }
    }
}

