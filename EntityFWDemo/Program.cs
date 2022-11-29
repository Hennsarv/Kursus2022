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
            NorthwindEntities db = new NorthwindEntities();
            db.Database.Log = Console.WriteLine; // päriselus me seda ei tee

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

            var qe = db.Employees.ToList()
                .Select(x => new { x.FullName, ManagerName = x.Manager?.FullName??"isejumal" });

            foreach (var e in qe) Console.WriteLine(e);

        }
    }
}
