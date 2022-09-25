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

            if (formFile.Count > 5)
            {
                return new ErrorResult("işlem hatalı");
            }

            carImage.ImagePath = _fileHelper.Upload(formFile, PathConstants.GetImagesPath());
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
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.GetImagesPath() + carImage.ImagePath,PathConstants.GetImagesPath());
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccesResult("işlem başarılı");
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccesDataResult<CarImage>(_carImageDal.Get(i => i.ImageId == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccesDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


    }
}
