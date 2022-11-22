using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammiPlokid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
                Console.WriteLine("täna lähen laulma");
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
                Console.WriteLine("täna lähen sauna");
            }
            else
            {
                Console.WriteLine("täna ei lähe laulma");
            }

            // kui vähegi võimalik, siis selle asemel proovi ?: tehet
            Console.WriteLine
                (
                    "täna lähen " + 
                    (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday ? "laulma" :
                    DateTime.Today.DayOfWeek == DayOfWeek.Saturday ? "sauna" :
                    DateTime.Today.DayOfWeek == DayOfWeek.Sunday ? "jooma" :
                    "koju")
                );

            // järgmine plokk on switch
            // teen näite, mis sarnane if-lausele

            switch(DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Tuesday:
                    Console.WriteLine("Täna lähen laulma");
                    break;
                case DayOfWeek.Sunday:
                    Console.WriteLine("Täna lähen jooma");
                    break;
                case DayOfWeek.Saturday:
                    Console.WriteLine( "Täna lähen sauna");
                    goto case DayOfWeek.Sunday;
                default:
                    Console.WriteLine("Täna lähen koju");
                    break;
            }

            // siiani olid valikulaused ehk hargemislaused või plokid
            // program block ehk programmiplokk

            // Edasi tsüklid ehk korduslaused ehk kordusplokid

            int[] numbrid = { 1, 2, 3, 4, 5, 6 };
            
            for (int i = numbrid.Length; ;  )
            {
                Console.WriteLine($"joome {numbrid[--i]} pudelit");
                if (i == 0) break;
            }

            foreach(var x in numbrid)
                Console.WriteLine($"joome {x} pudelit õlut");

            Console.Write("Kes sa oled:");
            for (string nimi = Console.ReadLine(); nimi != string.Empty; nimi = Console.ReadLine())
            {
                 
                Console.WriteLine($"Tere {nimi}, aga osta elevant ära!");
                Console.Write("Kes sa oled:");
            }

            string nimix;
            do
            {
                Console.Write("Kes sa oled: ");
                nimix = Console.ReadLine();
                if (nimix != string.Empty) Console.WriteLine($"{nimix} lähme jooma");
            } while (nimix != string.Empty);


        }
    }
}
