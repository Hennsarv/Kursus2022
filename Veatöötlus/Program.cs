using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Veatöötlus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nhakkame arvutama\n");

            while (true)
            {
                try // siin plokis me püüame vead kinni ja anname catchidele
                {
                    Console.Write("Anna üks arv: ");
                    int üks = int.Parse(Console.ReadLine());

                    Console.Write("Anna teine arv: ");
                    int teine = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nma nüüd jagan ...\n");
                    Thread.Sleep(1000);

                    Console.WriteLine($"jagatis on {üks / teine}");
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("ära sina nullliga küll jagamist proovi");
                }
                
                catch( FormatException e)
                {
                    Console.WriteLine("proovi täpsemalt toksida");
                }

                catch (Exception e)
                {
                    Console.WriteLine("oihh miski läks valesti");
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e);
                    throw e;
                }

                finally 
                {
                    Console.WriteLine("\nnüüd maksame arved\n");
                    Thread.Sleep(3000);
                }
            }

        }
    }
}
