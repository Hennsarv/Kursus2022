using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Klassid // neist räägime veel
{
    static class Program
    {

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

            

            Console.WriteLine(henn);
            Console.WriteLine(new Inimene { Nimi = "Jaagup"});

            Console.WriteLine(henn.Vanus);

        }


        

    }
    
    

    
}


