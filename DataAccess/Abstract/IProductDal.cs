using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        //List<Product> GetAll(); // urun listeleme 
        //void Add(Product product);//ekleme
        //void Update(Product product);// güncelleme
        //void Delete(Product product);// silme 

        //List<Product> GetAllCategory(int categoryId); //categoriye göre listeleme( category seçtiğimizde çalışan kod)
        List<ProductDetailDto> GetProductDetails();
    }
}
// code refactoring