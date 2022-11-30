using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaksiJuurdeAsju
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Jaga(21,koefitsient: 0.8, jagaja:3));

            int s = Liida(1, 2, 3, 4, 5, 6, 7);
            s = Liida(1, 2, 3);

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"{i}. {args[i]}");
            }

            
        }

        static double Jaga(int jagatav, int jagaja = 1, double koefitsient = 1) 
        { 
            return (jagaja== 0? 0 : (jagatav / jagaja)) * koefitsient;
        }

        static int Liida(int a) => a + 1;
        //static int Liida(int a, int b) => a + b;
        //static int Liida(int a, int b, int c) => a + b + c;

        static int Liida(int a, params int[] m) => a + m.Sum();

    }
}
