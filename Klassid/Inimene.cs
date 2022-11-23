using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klassid
{
    public class Inimene // reference
    {
        // klassi liikmed ehk Member
        public string Nimi;
        public DateTime SünniAeg { get; set; } = DateTime.Today;
        private int _Palk;
        public int Palk
        {
            get => _Palk; 
            set => _Palk = value > _Palk ? value : _Palk; 
        }
        //private int _kinganumber;
        public int Kinganumber 
        { get  ; set; }


        public int getPalk() => _Palk;
        public void setPalk(int uusPalk) => _Palk = uusPalk > _Palk ? uusPalk : _Palk;
        
        // read-only property - puudub set
        public int Vanus => (DateTime.Today - SünniAeg).Days * 4 / 1461;
            
        

        public override string ToString() => $"{Nimi} saab palka {Palk} ja on sündinud {SünniAeg:dd.MM.yyyy}";




    }
}
