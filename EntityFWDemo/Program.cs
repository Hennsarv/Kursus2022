using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFWDemo
{
    partial class Employee
    {
        public string FullName => FirstName + " " + LastName;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities1 db = new NorthwindEntities1();


            //db.Database.Log = Console.WriteLine; // päriselus me seda ei tee

            var q = db.Products
                .Where(x => x.UnitPrice < 10)
                .Select(x => new 
                { x.ProductName, x.UnitPrice, x.Category.CategoryName });

            //foreach (var item in q) Console.WriteLine(item);


            //var p8 = db.Categories
            //    .Find(8).Products
            //    .Select(x => x.ProductName)
            //    ;
            // foreach (var x in p8) Console.WriteLine(x);

            //var qe = db.Employees.ToList()
            //    .Select(x => new { x.FullName, ManagerName = x.Manager?.FullName??"isejumal" });

            ////foreach (var e in qe) Console.WriteLine(e);

            var lakkalikööri = db.Products.Find(76);
            Console.WriteLine(lakkalikööri.UnitPrice);

            lakkalikööri.UnitPrice = 18;

            db.SaveChanges();

            //var uus = new Product
            //{
            //    ProductName = "Jääkaru",
            //    UnitPrice = 100,
            //    UnitsInStock = 3
            //};

            //db.Products.Add(uus);
            //db.SaveChanges();

            db.Products
               .Select(x => new { x.ProductName, x.UnitPrice })
               .ToList()
               .ForEach(x => Console.WriteLine(x));

            var karu = db.Products
                .Where(x => x.ProductName == "Jääkaru")
                .FirstOrDefault();

            if(karu != null)
            {
                db.Products.Remove(karu);
                db.SaveChanges();
            }

        }
    }
}
