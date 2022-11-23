using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsimeseYlesandeLahendused
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Valgusfoori ülesanne
            // meil on vaja küsida valgusfoori värvi
            // meil on vaja erinevalt reageerida
            // meil on vaja seda mitu korda teha
            // teatud juhul vaja lõpetada
            
            for(bool jätka = true; jätka;)
            {
                Console.WriteLine("mis värv on?");
                //string värv = Console.ReadLine();
                
                switch (
                    Console
                        .ReadLine()
                        .Substring(0,2)
                        .ToLower()
                    )
                {
                    case "pu": case "re":
                        Console.WriteLine("seisa ja oota"); 
                        break;
                    case "kõ":
                    case "ko":
                    case "ye":
                        Console.WriteLine("kohe tuleb roheline, oota");
                        break;
                    case "ro":
                    case "gr":
                        Console.WriteLine("sõida!");
                        jätka = false;
                        break;
                    default:
                        Console.WriteLine("pese silmad");
                        break;

                }

            }

            // vaja lugeda nimed ja vanused
            // õnneks on arv teada - saab kasutada massiivi
            // tuleks teha tsükkel (kaks tsüklit) lugemiseks
            // tuleb leida ka min, max, avg - sum/count

            const int MAX_INIMESI = 10;
            string[] nimed = new string[MAX_INIMESI];
            int[] vanused = new int[MAX_INIMESI];
            int inimesi = 0;
            for (; inimesi < MAX_INIMESI; inimesi++)
            {
                Console.Write($"anna {inimesi+1}. nimi: ");
                nimed[inimesi]= Console.ReadLine();
                if (nimed[inimesi].Length == 0) break;
            }

            for (int i = 0; i < inimesi; i++)
            {
                Console.Write($"kui vana on {nimed[i]}: ");
                //vanused[i] = int.Parse(Console.ReadLine());
                //while (! int.TryParse(Console.ReadLine(), out vanused[i] ))
                //{
                //    Console.Write("anna uuesti: ");
                //}

                vanused[i] = int.TryParse(Console.ReadLine(), out int x) ? x : 0;


            }

            Console.WriteLine(string.Join(", ", nimed));
            Console.WriteLine(string.Join(", ", vanused));
            // nüüd oleks vaja leida, kes on noorim
            // kes on vanim ja keskmine   min, max, avg = sum / count

            int summa = 0;
            for (int i = 0; i < inimesi; i++) summa += vanused[i];
            if (inimesi>0)
            Console.WriteLine($"keskmine vanus on {(double)summa / inimesi}");
            else
            Console.WriteLine("rahvast pole");

            //Console.WriteLine(vanused.Where(x => x != 0).Average());

            int max = vanused[0]; int vanim = 0;
            int min = vanused[0]; int noorim = 0;

            for (int i = 1; i < inimesi; i++)
            {
                if (vanused[i] > max) { max = vanused[i]; vanim = i; }
                if (vanused[i] < min) { min = vanused[i]; noorim = i; }
            }

            Console.WriteLine($"noorim on {nimed[noorim]} ta on {vanused[noorim]} aastane");
            Console.WriteLine($"vanim on {nimed[vanim]} ta on {vanused[vanim]} aastane");


        }
    }
}
