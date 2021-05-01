using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Abstract
{
    //generic constraint --- T harfini sınırlandırma kısıtlama

    // buradakı class referans tip ola bilir demek 

    //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir (yani IEntity imzasını taşıyan class olabilir demek)

    //new(): new'lenebilir olmalı IEntity interface olduğundan new() lenemiyor
    public interface IEntityRepository<T> where T:class, IEntity,new()
    {
        //repostoriy oluşturma
        List<T> GetAll(Expression<Func<T,bool>> filter=null); // urun listeleme 
        // T dödüren Get operasyonu
        T Get(Expression<Func<T, bool>> filter );

        void Add(T entity);//ekleme       **//entity genel simdir 
        void Update(T entity);// güncelleme
        void Delete(T entity);// silme 

       // List<T> GetAllCategory(int categoryId);//Expression<Func<T,bool>> filter=null yapıyı yukarda kullandıktan sonra böyle bir sorguya ihtiyac duyulmaz artık
    }
}
