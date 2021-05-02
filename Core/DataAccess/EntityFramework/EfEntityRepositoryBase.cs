using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext,new()
    {
        public void Add(TEntity entity)
        {
            // bu usin yukarda kullanılan using değil
            //Idisposable pattern implementation of c# 
            // belleği hızlıca boşaltma 
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);// referansı yakalama
                addedEntity.State = EntityState.Added; // eklenecek bir nesne 
                context.SaveChanges(); // yukardakı ekleme işlemini tamamlar 

            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);// referansı yakalama
                deletedEntity.State = EntityState.Deleted; // silinecek bir nesne 
                context.SaveChanges(); // yukardakı silinecek işlemini tamamlar 

            }

        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //Get sadece bir datayı getirir
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
                //tek kayıt döndür yoksada default kalsın
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //GetAll tüm datayı getirir
            using (TContext context = new TContext())
            {
                //select * from products döndüren kod
                //filtre verdiysede ona göre bul ve döndür
                //filtre null mı?
                return filter == null 
                    ? context.Set<TEntity>().ToList() 
                    : context.Set<TEntity>().Where(filter).ToList(); 

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);// referansı yakalama
                updatedEntity.State = EntityState.Modified; // güncellenecek bir nesne 
                context.SaveChanges(); // yukardakı güncelleme işlemini tamamlar 

            }
        }

    }
}
