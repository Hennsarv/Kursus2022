using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Klassid
{
    public class Inimene // reference
    {
        static int nr = 0;
        readonly int _Nr = ++nr;
        public int Nr => _Nr;

        public static int Inimesi => nr;

        public static string Inimest =>
            nr == 0 ? "meil pole ühtegi inimest" :
            nr == 1 ? "meil on üks inimene" :
            $"meil on {nr} inimest";

        private string _IK;
        public string IK { get => _IK; set => _IK = _IK == "" ? value : _IK; }
        
        public static Dictionary<int, Inimene> Inimesed 
            = new Dictionary<int, Inimene>();

        public Inimene() => Inimesed.Add(nr, this);



        // klassi liikmed ehk Member
        private string _Eesnimi;
        private string _Perenimi;
        public string Eesnimi
        {
            get => _Eesnimi;
            set => _Eesnimi = value.ToProper();
        }
        public string Perenimi
        {
            get => _Perenimi;
            set => _Perenimi = value.ToProper();
        }

        public string Nimi
        {
            get => _Eesnimi + " " + Perenimi;
            set
            {
                var nimed = value.Split(' ');
                Eesnimi = nimed[0];
                Perenimi = nimed[nimed.Length - 1]; 
            }
        }
        public DateTime SünniAeg { get; set; } = DateTime.Today;
        private int _Palk;
        public int Palk
        {
            get => _Palk;
            set => _Palk = value > _Palk ? value : _Palk;
        }
        //private int _kinganumber;
        public int Kinganumber
        { get; set; }


  //      public int getPalk() => _Palk;
  //      public void setPalk(int uusPalk) => _Palk = uusPalk > _Palk ? uusPalk : _Palk;

        // read-only property - puudub set
        public int Vanus => (DateTime.Today - SünniAeg).Days * 4 / 1461;



        public override string ToString() => $"{Nr}. {Nimi} saab palka {Palk} ja on sündinud {SünniAeg:dd.MM.yyyy}";



    }
}
