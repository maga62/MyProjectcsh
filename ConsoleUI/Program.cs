using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID in O sunu burada yaptık
    //Open Closed Principale

 

    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetAllByCategoriy(2))
            {
                Console.WriteLine(product.ProductName);
            }

            
        }
    }
}
