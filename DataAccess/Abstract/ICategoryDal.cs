using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>
    {
        //generik repostory dizayın petter
        //tekrarlann kod yapısını jenerikler ile çözüm sağlana bilir
        //Category yerine jenerik [T] ve IProductDal da aynı şekilde bu aşağdakı yapı tekrarlana kısam jenerik [T yapıla]
        //***********************************************//
        //List<Category> GetAll(); // urun listeleme 
        //void Add(Category category);//ekleme
        //void Update(Category category);// güncelleme
        //void Delete(Category category);// silme 

        //List<Category> GetAllCategory(int categoryId);
        //**************aradakı kod parçaçığa gerek kalmadan kolay şekilde jenerikleme 
    }
}
