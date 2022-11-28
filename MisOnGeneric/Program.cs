using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

// räägime lahti kaks mõistet
// Generikud
// Extensionid

namespace MisOnGeneric
{
    static internal class Program
    {
        //static IEnumerable<int> Paaris(this IEnumerable<int> list)
        //{
        //    foreach (int i in list) { if (i % 2 == 0) yield return i; }
        //}
        //static IEnumerable<int> Paaritu(this IEnumerable<int> list)
        //{
        //    foreach (int i in list) { if (i % 2 != 0) yield return i; }
        //}
        static IEnumerable<int> 
            Millised(this IEnumerable<int> list, Func<int,bool> f)
        {
            foreach (int i in list) { if (f(i)) yield return i; }
        }

        //static bool KasPaaris(int x) => x % 2 == 0;

        static IEnumerable<TR> MySelect<Ti, TR> (this IEnumerable<Ti> list, Func<Ti,TR> f)
        {
            foreach (var ti in list) { yield return f(ti); }
        }


        static void Main(string[] args)
        {
            decimal a = 3; decimal b = 4;
            Console.WriteLine($"a={a} b={b}");
            vaheta(ref a, ref b);
            Console.WriteLine($"a={a} b={b}");

            int[] arvud = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            foreach (var x in arvud.Where(x => x%2 == 0))
            {
                Console.WriteLine(x);
            }

            var nimed = new List<string> { "Henn", "Ants", "Peeter" };
            foreach (var x in nimed.Where(n => n.Length == 4)) Console.WriteLine(x);

            foreach (var v in arvud
                .Select(x => x * x)
                .Skip(3)
                .Take(2)
                ) Console.WriteLine(v);
            Console.WriteLine("\nnäide nimekirjaga\n");
            string filename = @"..\..\nimekiri.txt";
            foreach(var nimi in 
                System.IO.File.ReadAllLines(filename)
                .Select(x => x.Split(','))
                .Select(x => new {Nimi = x[0], Vanus = int.Parse(x[1]) })
                .OrderBy(x => x.Vanus)
                ) Console.WriteLine(nimi);

            var uuednimed = from x in System.IO.File.ReadAllLines(filename)
                        .Select(x => x.Split(','))
                            where x.Length > 1
                            select new { Nimi = x[0], Vanus = int.Parse(x[1]) }
                        ;

            var dict = uuednimed.ToDictionary(x => x.Nimi, x => x);
            
            Console.WriteLine(dict["Henn"]);

            //foreach (var x in uuednimed) Console.WriteLine(x);
        }   // LINQ - language integrated query

        static void vaheta<T>(ref T x, ref T y)
        {
            //(x, y) = (y, x); // moodne vahetus
            T z = x; x = y; y = z; // vanamoodne vahetus

        }






    }
}
