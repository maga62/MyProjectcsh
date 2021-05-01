using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet farklı proje paketleri kullanıldığıve yönetildiği alan
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            // bu usin yukarda kullanılan using değil
            //Idisposable pattern implementation of c# 
            // belleği hızlıca boşaltma 
            using (NorthwindContext context= new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);// referansı yakalama
                addedEntity.State = EntityState.Added; // eklenecek bir nesne 
                context.SaveChanges(); // yukardakı ekleme işlemini tamamlar 

            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);// referansı yakalama
                deletedEntity.State = EntityState.Deleted; // silinecek bir nesne 
                context.SaveChanges(); // yukardakı silinecek işlemini tamamlar 

            }

        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            //Get sadece bir datayı getirir
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
                //tek kayıt döndür yoksada default kalsın
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            //GetAll tüm datayı getirir
            using (NorthwindContext context = new NorthwindContext())
            {
                //select * from products döndüren kod
                //filtre verdiysede ona göre bul ve döndür
                return filter == null //filtre null mı? 
                    ? context.Set<Product>().ToList() // Evet ise bu çalışır
                    : context.Set<Product>().Where(filter).ToList(); // Hayır ise bu çalışır

            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);// referansı yakalama
                updatedEntity.State = EntityState.Modified; // güncellenecek bir nesne 
                context.SaveChanges(); // yukardakı güncelleme işlemini tamamlar 

            }
        }
    }
}
