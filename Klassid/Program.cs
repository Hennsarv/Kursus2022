using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klassid // neist räägime veel
{
    static class Program
    {
        internal static string ToProper(this string x) =>
            x.Trim().Substring(0, 1).ToUpper()
            +
            x.Trim().Substring(1).ToLower()
            ;

        // näidiseks veel üks funktsioon
        #region MyRegion
        //static string Koos(this Inimene i)
        //{
        //    return $"{i.Nimi} vanusega {i.Vanus}";
        //}
        //static string KokkuPane(Inimene i)
        //{
        //    return $"{i.Nimi} vanusega {i.Vanus}";
        //}

        //static void TrykiInimene(this Inimene i)

        //    => Console.WriteLine(i.PaneKokku()); 
        #endregion

        static void Main()
        {
            
            Inimene henn = new Inimene
            {
                Nimi = "Henn Sarv",
                SünniAeg = new DateTime(1955,3,7),
                Palk = 4000
            };
            
            henn.Palk += 1000;
            henn.Perenimi = "sarviktaat";

            Console.WriteLine(henn.ToString());
            Console.WriteLine(new Inimene { Nimi = "jaagup"});

            new Inimene { Nimi = "Luarvik" };

            //Console.WriteLine(henn.Vanus);

            Console.WriteLine(Inimene.Inimest);

            Console.WriteLine(Inimene.Inimesed[3]);

            List<string> nimed = new List<string>();
            
            Dictionary<int, NimiSugu> nimedsood = new Dictionary<int, NimiSugu>();
            nimedsood.Add(1, new NimiSugu { Nimi = "Henn", Sugu = Sugu.Mees });
            nimedsood.Add(2, new NimiSugu { Nimi = "Anne", Sugu = Sugu.Naine });
            nimedsood.Add(3, new NimiSugu { Nimi = "Malle", Sugu = Sugu.Naine });
            nimedsood.Add(4, ("Kalle", Sugu.Mees));

            Dictionary<int, (string nimi, Sugu sugu)> ns = new Dictionary<int, (string, Sugu)>();
            ns.Add(1, ("Henn", Sugu.Mees));

            foreach (var x in nimedsood) Console.WriteLine(x);

            Console.WriteLine(ns[1].sugu);
            


        }




    }

    enum Sugu { Mees, Naine}

    enum Mast { Risti, Ruutu, Ärtu, Poti, Pada=3}

    class NimiSugu
    {
        public string Nimi;
        public Sugu Sugu;

        public NimiSugu() { }
        public NimiSugu(string nimi, Sugu sugu) => (Nimi, Sugu) = (nimi, sugu);

        public override string ToString() => $"{Sugu} {Nimi}";

        public static implicit operator NimiSugu((string nimi, Sugu sugu) x) => new NimiSugu(x.nimi, x.sugu);
        
    }
    
    

    
}


