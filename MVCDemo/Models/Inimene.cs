using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class Inimene
    {
        public static Dictionary<int, Inimene> Inimesed
            = new Dictionary<int, Inimene>
            {
                {1, new Inimene {Id = 1,Nimi = "Henn", Vanus = 67} },
                {2, new Inimene {Id = 2,Nimi = "Ants", Vanus = 40} },
                {3, new Inimene {Id = 3,Nimi = "Peeter", Vanus = 28} },
            };

        public int Id { get; set; }
        public string Nimi { get; set; }
        public int Vanus { get; set; }
    }
}