using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ÜlesanneKaks
{
    internal class Program
    {
        static string folderName = @"..\..\..\"; // testime

        static string[] readFile(string filename) 
            => System.IO.File.ReadAllLines
            ($"{folderName}{filename}.txt");
        static void Main(string[] args)
        {
            foreach 
                (var x in 
                    readFile("Õpilased")
                    .Select(x => x.Split(',').Select(y => y.Trim()).ToArray())
                    .Select(x => new 
                                {
                                    IK = x[0], 
                                    Nimi = x[1], 
                                    Klass = x[2],  
                                    KasÕpetja = false    
                                })
                )
            {
                Console.WriteLine(x);
            }
        }
    }
}
