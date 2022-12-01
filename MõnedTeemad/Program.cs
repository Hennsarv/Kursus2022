using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MõnedTeemad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Inimene.New("35503070211").Nimi = "Henn";
            //Inimene.New("35503070212").Nimi = "Sarvik";

            //Inimene.Get("35503070211").Remove();


            //foreach (var i in Inimene.Inimesed) Console.WriteLine(i);

            //Inimene inimene = Inimene.Get("35503070212");

            //Console.WriteLine(inimene);

            Inimene inimene = new Inimene
            {
                IK = "35503070211",
                Nimi = "Henn",
                Vanus = 67,
                Sünniaeg = new DateTime(1955,3,7)
            };

            var pere = new List<Inimene>
            {
                inimene,
                new Inimene {IK = "45705210329", Nimi = "Maris", Vanus =65}
            };

            string inimstring = JsonConvert.SerializeObject(pere);
            Console.WriteLine(inimstring);

            var uuslist = JsonConvert.DeserializeObject<Inimene[]>(inimstring);

            foreach (var uus in uuslist) { Console.WriteLine(uus); }




        }
    }

    class Rahakott : IDisposable
    {
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        ~Rahakott()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }


    class Inimene
    {
        //static Dictionary<string,Inimene> inimesed = new Dictionary<string,Inimene>();
        //public static IEnumerable<Inimene> Inimesed => inimesed.Values;

        static int loendur = 0;
        int nr = ++loendur;
        public string IK { get; set; }
        public string Nimi { get; set; }

        public DateTime? Sünniaeg { get; set; }

        public int Vanus { get; set; } = 67;
        //konstructor
        //private Inimene(string IK) { this.IK = IK; inimesed.Add(IK, this); }

        ////destructor
        ////~Inimene() { Console.WriteLine($"kaob inimene {this}"); }

        //public static Inimene Get(string IK) =>
        //    inimesed.Keys.Contains(IK) ? inimesed[IK] : null;

        ////public static void Remove(Inimene i) => inimesed.Remove(i.IK);
        //public void Remove()
        //{
        //    inimesed.Remove(this.IK);
        //    GC.SuppressFinalize(this);
        //}

        //public static Inimene New(string IK) { 
        //    if (inimesed.ContainsKey(IK)) return inimesed[IK];
          
        //    return new Inimene(IK); }

        public override string ToString() => $"{nr}. {Nimi}";
        


    }



}
