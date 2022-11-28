using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControllerApp
{
    class Inimene
    {
        public string Eesnimi { get; set; }
        public string Perenimi { get; set; }
        public int Vanus { get; set; }

        public string Nimi { get { return $"{Eesnimi} {Perenimi}"; } }

        public override string ToString() => $"Inimene: {Nimi} vanusega: {Vanus}";
    }

    static class Program
    {
        static string FolderName = @"..\..\";
        static string FileName = FolderName + "andmed.txt";
        static string FileName2 = FolderName + "tulemus.txt";

        static string[] sisu = null;  // siia loeme näidisfaili sisu

        static string Menüü =
        @"
        1 - esimene valik
        2 - teine valik
        n - loe näidisfail
        t - salvesta tulemus
        a - loe andmed
        väljumiseks vakita enter
        ";

        static string Küsi(string küsimus)
        {
            Console.Write($"{küsimus}: ");
            return Console.ReadLine();
        }

        static string Menüüst(string k) => Küsi($"{Menüü}\n{k}");
        //{ 
        //    return Küsi($"{Menüü}\n{k}"); 
        //}
        static void Main(string[] args)
        {
            for (var r = Menüüst("mis teeme"); r != ""; r = Menüüst("mis edasi"))
            {
                switch (r.ToLower())
                {
                    #region näidiskeisid
                    case "1":
                        Console.WriteLine("esimene valik oli see");
                        break;
                    case "2":
                        Console.WriteLine("teine valik oli see");
                        break;
                    #endregion
                    case "n":
                        sisu = File.ReadAllLines(FileName);
                        for (int i = 0; i < sisu.Length; i++)
                        {
                            Console.WriteLine($"{i:d2}|{sisu[i]}|");
                        }

                        break;
                    case "t":

                        if (sisu != null)
                        {
                            File.WriteAllLines(FileName2, sisu);
                        }
                        break;
                    case "a":
                        // faili peame mällu ikka lugema (kui ta seal juba ei ole)
                        if (sisu == null) sisu = File.ReadAllLines(FileName);
                        List<Inimene> inimesed = new List<Inimene>();
                        foreach(var x in sisu) 
                        {
                            var o = x.Split(',');
                            Inimene i = new Inimene
                            {
                                Eesnimi = o[0].Trim(),
                                Perenimi = o[1].Trim(),
                                Vanus = int.Parse(o[2].Trim())
                            };
                            inimesed.Add(i);
                        }
                        foreach (var x in inimesed) Console.WriteLine(x);

                        break;



                }
            }

        }
    }
}
