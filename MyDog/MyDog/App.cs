using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyDog
{
    partial class App
    {

        DataAccess _dataAccess = new DataAccess();

        public void Run()
        {                                            //(Kritisk användare), finns det inget namn på appen eller logga? 
                                                     // undrar Agda 87. Jag har ingen
            PageMainMenu();                          // aning om vad jag har öppnat för nå program D:
        }                                         

        private void PageMainMenu()
        {
            Console.Clear();
            Header("Menu");
            Console.WriteLine("a) Exhibitors");               // (kritisk programmerare) För mycket tomma funktioner.
            Console.WriteLine("b) Rings");
            Console.WriteLine("c) Dogs");
            Console.WriteLine("d) Breeds");

            ConsoleKey command = Console.ReadKey(true).Key;           // Stor välhanterad databas med bra exempel och info! :)

            if (command == ConsoleKey.A)
                PageExhibitors();

            if (command == ConsoleKey.B)
                PageRings();

            if (command == ConsoleKey.C)
                PageDogs();

            if (command == ConsoleKey.D)
                PageBreeds();
        }                                                         // else sats hade hjälpt, gärna med en consolekey.escape för att avsluta


        private void Header(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
            Console.ResetColor();
        }

        private void WriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private void WriteRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
