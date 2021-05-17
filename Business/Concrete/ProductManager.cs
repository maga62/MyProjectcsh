using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
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

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }


        [ValidationAspect(typeof(ProductValidator))]// add metoduna validation yok aspect ekledik
        public IResult Add(Product product)
        {
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

            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
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
    }
}
