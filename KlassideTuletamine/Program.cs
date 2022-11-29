using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KlassideTuletamine
{
    static internal class Program
    {
        static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) action(item);
        }

        static void Main(string[] args)
        {
            Loom kroku = new Loom("krokodill"); //{ Liik = "krokodill" };
            new Loom();

            new Koduloom("prussakas") { Nimi = "Mati" };
            var kiisu = new Kass("siiam", "Miisu");
            (new Kass("siiam", "Täpi")).Sikuta();
            var k = new Koer("Pauka");

            //foreach (var item in Loom.LoomaAed) Console.WriteLine(item);

            Loom.LoomaAed.ForEach(x => x.TeeHäält());

            ISöödav s = new Sepik();
            Lõuna(s);
            Lõuna(k);

            foreach (var item in Loom.LoomaAed)
            {
                if (item is Kass kk) kk.Silita(); 
            }

            Loom.LoomaAed.ForEach(x => x.TeeHäält());

        }

        static void Lõuna(object x)
        {
            //if (x is ISöödav xs) xs.Süüakse();
            //else Console.WriteLine("Nälg");

            ISöödav sx = (x as ISöödav);
            ISöödav sy = x is ISöödav ? (ISöödav)x : null;
        }

    }

    // public - seda asja saab kasutada KÕIKJALT
    // private - seda asja saab kasutada AINULT SELLE KLASSI SEES
    // internal - ühe programmi (Assambly) ulatuses on näha
    // protected - seda asja saab kasutada selles ja tuletatud klassis

    // static versus mittestatic

    class Loom
    {
        private static int loendur = 0;
        private static List<Loom> loomaAed = new List<Loom>();
        public static IEnumerable<Loom> LoomaAed = loomaAed.AsEnumerable();

        protected int nr { get; private set; } = ++loendur;
        //public int Nr => nr;

        public string Liik { get; protected set; }

        // new käsu täitmisel kutsutakse välja
        public Loom(string Liik) { this.Liik = Liik; loomaAed.Add(this); }

        //public Loom() { Liik = "tundmatu"; loomaAed.Add(this); }

        public virtual void TeeHäält() => Console.WriteLine($"{this} teeb koledat häält");

        public Loom() : this("tundmatu") { }

        public override string ToString() => $"{nr}. Loom liigist {Liik}";


    }

    // mis on parem kui jäätis? - kaks jäätist
    // mis on parem kui klass? - mitu klassi

    class Koduloom : Loom
    {
        public string Nimi { get; set; }

        public Koduloom(string liik) : base(liik) { }
        public Koduloom() : base("tundmatu") { }

        public override string ToString() => $"{nr}. {Liik} {Nimi}";

        public override void TeeHäält() => Console.WriteLine($"{this} teeb mahedat häält");


    }

    class Kass : Koduloom
    {
        public string Tõug { get; set; }
        private bool tuju = true;

        public Kass(string tõug, string nimi) : base("kass")
        {
            Tõug = tõug;
            Nimi = nimi;
        }

        public void Silita() => tuju = true;
        public void Sikuta() => tuju = false;

        public override void TeeHäält()
        {
            if (tuju)
                Console.WriteLine($"{this} lööb nurru");
            else
                Console.WriteLine($"{this} kräunub");

        }

    }

    class Koer : Koduloom, ISöödav
    {
        public Koer(string nimi) : base("koer") { Nimi = nimi; }

        public override void TeeHäält() => Console.WriteLine($"{this} haugub");

        public void Süüakse()
        {
            Console.WriteLine($"{this} pistetakse nahka");
        }
    }

    class Sepik : ISöödav
    {
        public void Süüakse()
        {
            Console.WriteLine("Keegi nosib sepikut");
        }
    }

    interface ISöödav
    {
        void Süüakse();
    }
}
