using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace Dynaamikud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arvud = { 1, 2, };

            object[] asjad = { 1, 2, "seebikarp" };

            arvud[1]++;
            asjad[1] = (int)(asjad[1])+1;

            dynamic d = 7;
            Console.WriteLine(d.GetType().Name);

            Console.WriteLine(++d);

            d = "seebikarp";
            Console.WriteLine(d.GetType().Name);
     

            d = (Func<int, int>)( (x) => x * x + 7);

            Console.WriteLine(d(4));

            dynamic sk = new Seljakott();
            sk.Nimi = "Henn";
            Console.WriteLine(sk.Nimi);

            sk.Vanus = 67;
            Console.WriteLine(sk.Vanus);

            sk.Kinganumber = 45;
            Console.WriteLine(sk.Kinganumber??0);

        }
    }

    class Seljakott : DynamicObject
    {
        Dictionary<string,dynamic> sisu 
            = new Dictionary<string,dynamic>();

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            
                result =
                    sisu.ContainsKey(binder.Name) ? 
                    sisu[binder.Name] : null;

            return true;
            
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            sisu[binder.Name] = value;
            return true;
        }



    }

}
