using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kollektsioonid
{
    internal class Program
    {
        static Random r = new Random();

        static void Main(string[] args)
        {
            // massiiv ja list

            int[] arvud = new int[100]; // 100 asemel võib olla int-tüüpi avaldis
            arvud[17] = 200; // pöördumine 18. elemendi poole
            arvud[17]++;
            arvud[17] *= 2;

            //byte[] puhver = new byte[10_000_000_000]; // paha

            List<int> list = new List<int>(20);
            // alguses ei ole siin ühtegi arvu!!
            for (int i = 0; i < 10; i++)
            {
                list.Add(r.Next(0, 25));
                Console.WriteLine($"listis on {list.Count} arvu, sinna mahub {list.Capacity}");


            }
            Console.WriteLine(string.Join(",", list));
            list.Remove(24);
            Console.WriteLine(string.Join(",", list));

            var m = list.ToArray();
            var l = m.ToList();

            int[] a2 = { 1, 22, 4, 35, 26, 17, 8, };
            list.Union(a2);

            List<string> nimed = new List<string> { "Henn", "Ants", "Peeter" };

            Console.WriteLine("\nStäkk ja Järjekord\n");

            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();

            foreach (var x in a2)
            {
                stack.Push(x);
                queue.Enqueue(x);
            }

//            Console.WriteLine(string.Join(",", stack));
//            Console.WriteLine(string.Join(",", queue));

            while (queue.Count > 0) { Console.WriteLine(queue.Dequeue()); }
            while (stack.Count > 0) { Console.WriteLine(stack.Pop()); }

            Console.WriteLine("\nsortedset\n"  );

            SortedSet<int> sorted =
                new SortedSet<int> { 1, 22, 4, 35, 26, 17, 8, };

            //sorted.Add(22);
            Console.WriteLine(string.Join(",", sorted));

            Console.WriteLine("\nSõnastikud\n");

            Dictionary<int, string> nimekiri = new Dictionary<int, string>();

            nimekiri.Add(7, "Henn");
            nimekiri.Add(11, "Joosep");
            nimekiri[7] = "Sarvik";

            Dictionary<string, int> hinded= new Dictionary<string, int>();
            hinded["Henn"] = 5;
            hinded["Ants"] = 2;
            hinded["Ants"]++;

            Console.WriteLine(string.Join(",", nimekiri));
            Console.WriteLine(string.Join(",", hinded));

            // foreach kolm varianti
            // Dictionary - key-value paarid
            // Dictionary.keys - võtmed
            // Dictionary.values - väärtused

            Dictionary<string, DateTime> sünnipäevad =
                new Dictionary<string, DateTime>
                {
                    { "Henn", new DateTime(1955, 3, 7) },
                    { "Ants", new DateTime(1960, 7, 20) },
                    { "Peeter", new DateTime(1940, 1, 8) },
                    { "Joosep", new DateTime(2000, 2, 29) },
                };

            Console.WriteLine(sünnipäevad["Henn"].DayOfWeek);









        }
    }
}
