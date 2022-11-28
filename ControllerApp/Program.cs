using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ControllerApp
{
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
                switch (r)
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

                }
            }

        }
    }
}
