using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;



        public ProductManager(IProductDal productDal, ICategoryService categoryService) //,IcategoryDal categoryDal yapamayız 
        {
            //bir entity manager kendisi hharic başka bir dalı enjecte edemez
            _productDal = productDal;
            _categoryService = categoryService;



        }


        [ValidationAspect(typeof(ProductValidator))]// add metoduna validation yok aspect ekledik
        public IResult Add(Product product)
        {      //----------->business kodlar buraya yazılır <-------




            // bu if lerin yapmış olduğu işlemleri ProductValidator a taşında 
            //if (product.Unitprice<=0)
            //{
            //    return new ErrorResult(Messages.UnitPriceInvalid);

            //}
            //if (product.ProductName.Length < 2)
            //{
            //    //(magic string) demek mesajın içi demek 
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}

            //ValidationTool.Validate(new ProductValidator(), product); ihtiyac kalmadı loglama işleme başında yazılı
            IResult result= BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());
            if (result!=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
            
            //kotu kod yazma bu ve yorum satirinda olan kdlar mimmariye uygun olarak yeniden tasarlanmiştir

            //_logger.Log();
            //try
            //{
            //    _productDal.Add(product);
            //    return new SuccessResult(Messages.ProductAdded);

            //}
            //catch (Exception exeption)
            //{

            //    _logger.Log();
            //}
            //return new ErrorResult();
        }

        public IDataResult< List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(),Messages.ProductsListed);

        } 

        public IDataResult<List<Product>> GetAllByCategoriy(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p =>p.CategoryId==id));//yukarda benim gönderdiğim id categoryid eşit ise filtrele

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult< Product > (_productDal.Get(p => p.ProductId == productId));

        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.Unitprice >= min && p.Unitprice <= max));

        }

        public IDataResult< List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }

        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {
            var Result = _categoryService.GetAll();
            if (Result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
