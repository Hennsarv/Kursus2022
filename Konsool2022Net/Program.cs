using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sql = System.Data.SqlClient;

namespace Konsool2022Net
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arvud1 = new int[10]; // array ehk massiiv
            int[] arvud2 = { 1, 2*2, 300,400 };

            string[] nimed = { "Henn", "Ants", "Peeter" };
            int[][] keeruline = { new int[] {1,2,333 }, new int[2], new int[] { } };
            Console.WriteLine(keeruline[0][2]);

            int[,] tabel = { { 1, 2, 3 }, { 4, 5, 77 }, { 6, 7, 99 }, { 3, 4, 5 } };
            Console.WriteLine(tabel[1,2]);

            var arvud3 = (int[])arvud2.Clone();
            arvud3[3] = 500;
            Console.WriteLine(arvud2[3]);

            Array.Resize(ref arvud3, 10);
            Console.WriteLine(tabel.Length); // 12
            Console.WriteLine(tabel.Rank); // 2
            Console.WriteLine(tabel.GetLength(0)); // 4
            Console.WriteLine(tabel.GetLength(1)); // 3
            Console.WriteLine(keeruline[0].Length);
            // avaldised

            int arv; double d;

            arv = (4 + 7) * (3 + 8); // 4 7 + 3 8 + * arv =
            d = Math.Sqrt(Math.PI * 3) + 100;

            int a;
            int b;

            Console.WriteLine( (a = 7) * (a = 8));
            Console.WriteLine(a);

            Console.WriteLine(a+=10); // 18 a on peale seda 18
            Console.WriteLine(a++);   // 18 a on peale seda 19
            Console.WriteLine(++a);   // 20 a on peale seda 20
            Console.WriteLine(a>>4);

            Console.WriteLine(a > 10 ? "suurem" : "väiksem");

            Console.WriteLine(
                DateTime.Now.DayOfWeek == DayOfWeek.Monday ? "valutame pead" :
                DateTime.Now.DayOfWeek == DayOfWeek.Tuesday ? "läheme laulma" :
                DateTime.Now.DayOfWeek == DayOfWeek.Wednesday ? "läheme trenni" :
                DateTime.Now.DayOfWeek == DayOfWeek.Saturday ? "läheme sauna" :
                DateTime.Now.DayOfWeek == DayOfWeek.Sunday ? "võtame viina" :
                "jääme koju"


                ); 


            // 

        }
    }
}
