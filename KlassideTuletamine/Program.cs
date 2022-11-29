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
            Loom kroku = new Loom { Liik = "krokodill" };
            new Loom();

            //foreach (var item in Loom.LoomaAed) Console.WriteLine(item);

            Loom.LoomaAed.ForEach(x => x.TeeHäält());          
        }
    }

    // public - seda asja saab kasutada KÕIKJALT
    // private - seda asja saab kasutada AINULT SELLE KLASSI SEES
    // internal - ühe programmi (Assambly) ulatuses on näha
    // protected - sellest räägib tulevikus

    // static versus mittestatic

    class Loom
    {
        private static int loendur = 0;
        private static List<Loom> loomaAed = new List<Loom>();
        public static IEnumerable<Loom> LoomaAed = loomaAed.AsEnumerable();

        private int nr = ++loendur;
        //public int Nr => nr;

        public string Liik;

        // new käsu täitmisel kutsutakse välja
        public Loom(string Liik) { this.Liik = Liik; loomaAed.Add(this); }

        //public Loom() { Liik = "tundmatu"; loomaAed.Add(this); }

        public void TeeHäält() => Console.WriteLine($"{this} teeb koledat häält");

        public Loom() : this("tundmatu") { }

        public override string ToString() => $"{nr}. Loom liigist {Liik}";
        

    }



}
