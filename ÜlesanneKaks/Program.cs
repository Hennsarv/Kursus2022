using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ÜlesanneKaks
{
    // lisan klasssile static (kuigi ta on niigi static)
    // siis saan samas klassis extensioneid teha
    static internal class Program
    {
        static void ForEach<T>(this IEnumerable<T> source, Action<T> action) 
        {
            foreach (T item in source) { action(item); }
        }

        static string folderName = @"..\..\..\"; // testime

        static IEnumerable<string[]> readFile(string filename) 
            // muutsin õpilase soovitusel tlemuse tüübi
            // ja tõstsin viimase rea ka funktsiooni sisse
            => System.IO.File.ReadAllLines
            ($"{folderName}{filename}.txt")
            .Select(x => (x+",").Split(',').Select(y => y.Trim()).ToArray())
            ;
        
        static void Main(string[] args)
        {
            var õpilased =
                    readFile("Õpilased")     // mugavuseks tegin omale funktsiooni
                    //.Select(x => x.Split(',').Select(y => y.Trim()).ToArray())
                    // see rida läks funktsiooni sisse
                    .Select(x => new
                    {
                        IK = x[0],
                        Nimi = x[1],
                        Klass = x[2],
                        KasÕpetaja = false,
                        MisAine = ""
                    })
                    .ToList();
            var õpetajad =
                readFile("õpetajad")     // mugavuseks tegin omale funktsiooni
                //.Select(x => (x+",").Split(',').Select(y => y.Trim()).ToArray())
                .Select(x => new
                {
                    IK = x[0],
                    Nimi = x[1],
                    Klass = x[3], // x.Length > 3 ? x[3] : ""
                    KasÕpetaja = true,
                    MisAine = x[2]
                })
                .ToList();
            var dict = õpetajad.Union(õpilased).ToDictionary(x => x.IK, x => x);
            //foreach (var x in dict) Console.WriteLine(x);
            var klassid = dict
                .Values
                .Where(x => !x.KasÕpetaja)
                .Select(x => x.Klass).Distinct().ToList();
            Console.Write("\nMeil on sellised klassid: ");
            Console.WriteLine(string.Join(",", klassid));
            Console.WriteLine("\nMeie õpetajad: ");
            dict.Values
                .Where(x => x.KasÕpetaja)
                //.ToList()
                .ForEach(x => Console.WriteLine(x));
            // listil on vahva extension, mida teisteel ei ole - ForEach
            // ma nalja pärast teen omale teiste jaoks ka

            Console.WriteLine("\nMeie õpilased: ");
            dict.Values
                .Where(x => !x.KasÕpetaja)
                .Select(x => $"{x.Klass}-i õpilane {x.Nimi}")
                //.ToList()
                .ForEach(x => Console.WriteLine(x));

            // keerukam variant õpilaste nimekirja
            dict.Values
                .Where(x => !x.KasÕpetaja)
                .GroupBy(x => x.Klass)
                .ForEach(x =>
                {
                    Console.WriteLine($"{x.Key} klassi õpilased (kokku {x.Count()}):");
                    x.Select(y => y.Nimi)
                    .ForEach(y => Console.WriteLine(y));
                }
                );

            Console.WriteLine("\nKoolipere: ");
            dict.Values
                .OrderBy(x => x.Nimi)
                .Select(
                    x => new {x.Nimi, Amet = (x.KasÕpetaja ? x.MisAine + " õpetaja" : "õpilane")}
                )
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
