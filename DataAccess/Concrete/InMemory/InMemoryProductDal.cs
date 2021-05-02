using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            //constructor
            //oracle,Sql sever ,Postgres,MongoDb den geliyormuşcasına veriler simile etme şekli
            _products = new List<Product> { 
                new Product{ProductId=1,CategoryId=1,ProductName="Masa",Unitprice=15,UnitsInstock=10},
                new Product{ProductId=2,CategoryId=1,ProductName="Bardak",Unitprice=500,UnitsInstock=100},
                new Product{ProductId=3,CategoryId=2,ProductName="Kamera",Unitprice=1500,UnitsInstock=8},
                new Product{ProductId=4,CategoryId=2,ProductName="Tablo",Unitprice=150,UnitsInstock=20},
                new Product{ProductId=5,CategoryId=2,ProductName="Davul",Unitprice=85,UnitsInstock=10},


            };


        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //,Net --- LİNQ - DİLE GÖMÜLÜ SORGULAMA YÖNTEMİ İLE YAZCAZ
            //Alternatif foreach bir bir gezeceğimize  Tek satırda SingleOrDefault(p=>....) kullnarak yapa bilriz
            //Product productToDelete = null;
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;

            //    }

            //}
            Product productToDelete = _products.SingleOrDefault(p=> p.ProductId == product.ProductId); //LİNQ
            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public void Update(Product product) //Product product -> ekrandan gelen data
        {   //güncelleme işlemleri 
            // gönderdiğim ürün İd sine  sahip olan listeddeki ürünü bul demek 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //LİNQ
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.Unitprice = product.Unitprice;
            productToUpdate.UnitsInstock = product.UnitsInstock;
           
        }


        public List<Product> GetAllCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList(); // where koşulu p => p.CategoryId == categoryId şarta uyan bütünelemanları yeni bir liste haline getiri ve onu döndürür 

        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
