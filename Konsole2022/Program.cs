using System;
namespace Konsole2022
{
    internal class Program
    {
        static void Main(string[] args) // lisame kommentaari
        {
            //Console.WriteLine("Hello, Maailm!");
            //Console.WriteLine("Koolitusel tehtud täiendus");

            decimal arv = 7; // muutuja tüüp on Int32 / int

            Console.WriteLine(
                DateTime.Now.DayOfWeek switch
                {
                    DayOfWeek.Monday => "valutame pead",
                    DayOfWeek.Tuesday => "läheme laulma",
                    DayOfWeek.Saturday => "läheme sAUNA",
                    _ => "Läheme koju"
                }
                );           


        }

        static void Uus() { } 
    }
}