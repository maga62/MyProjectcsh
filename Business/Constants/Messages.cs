using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçerssiz";
        public static string MaintenanceTime="sistem bakımda";
        public static string ProductsListed="Ürünler listelendi";
        public static string ProductCountOfCategoryError="bir kategoride en fazla 10 ürün ola bilir";
        public static string ProductNameAlreadyExists="bu isim altında zaten başka bir ürün var !";
        public static string CategoryLimitExceded="Kategory limiti aşıldığı için yeni ürün eklenemiyor";
    }
}
