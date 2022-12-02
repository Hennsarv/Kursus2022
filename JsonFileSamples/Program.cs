using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace JsonFileSamples
{
    internal class Program
    {
        static string menüü = @"
        1-genereeri Json ja salvesta faili
        2-loe Json failist ja näita ekraanil
        3-loe tundmatu Json ja näita ekraanil
    ";

        static string fileName = "..\\..\\test.json";
        static string Küsi(string midat)
        {
            Console.Write(menüü+midat + ": ");
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            for (string v = Küsi("mis teeme"); v != ""; v = Küsi("mis edasi"))
            {
                switch (v)
                {
                    case "1":
                        Console.WriteLine("\nTeeme struktuuri ja kirjutame JSON\n");
                        Esimene();
                        break;
                    case "2":
                        Console.WriteLine("\nLoeme Jsoni ja näitame struktuuri\n");
                        Teine();
                        break;
                    case "3":
                        Console.WriteLine("\nsee tehas, kes need kastid telllis ...\n");
                        Kolmas();
                        break;

                }

            }


        }

        static void Esimene() 
        {
            Lihtne[] lihtne = 
                {
                new  Lihtne { Algus = "ahaa", Keskel = 77, Lõpuks = "ohoo" },
                new  Lihtne { Algus = "uhaa", Keskel = 99, Lõpuks = "uhuu" },
            };

            Console.WriteLine(lihtne);

            string lihtneJ = JsonConvert.SerializeObject(lihtne);
            Console.WriteLine(lihtneJ);
            File.WriteAllText(fileName, lihtneJ);
                    
        }
        static void Teine() 
        { 
            string json = File.ReadAllText(fileName);
            Console.WriteLine(json);
            Lihtne[] res = JsonConvert.DeserializeObject<Lihtne[]>(json);
            Console.WriteLine(string.Join<Lihtne>("\n", res));

        }
        static void Kolmas()
        {
            string json = File.ReadAllText(fileName);
            Console.WriteLine(json);
            //object o = JsonConvert.DeserializeObject(json);
            //Console.WriteLine(o);
            var definition = new { m = new { Algus = "" } };

            dynamic res = JsonConvert.DeserializeObject(json);

            for (int i = 0; i < res.Count; i++)
            {
                Console.WriteLine(i+": " + res[i]);
            }

        }

    }

    public class Lihtne
    {
        public string Algus { get; set; } = "algus";
        public int Keskel { get; set; } = 0;
        public string Lõpuks { get; set; } = "lõpp";

        public override string ToString()
        => $"{Algus}-{Keskel}-{Lõpuks}";
    }

}
