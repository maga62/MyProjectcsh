using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public List<Product> GetAll()
        {
            //iş kodları 
            //yetkisi varmı 
            return _productDal.GetAll();

        } 

        public List<Product> GetAllByCategoriy(int id)
        {
            return _productDal.GetAll(p =>p.CategoryId==id);//yukarda benim gönderdiğim id categoryid eşit ise filtrele

        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.Unitprice >= min && p.Unitprice <= max);

        }
    }
}
