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
        {
            PageMainMenu();
        }

        private void PageMainMenu()
        {
            Console.Clear();
            Header("Menu");
            Console.WriteLine("a) Exhibitors");
            Console.WriteLine("b) Rings");
            Console.WriteLine("c) Dogs");
            Console.WriteLine("d) Breeds");

            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
                PageExhibitors();

            if (command == ConsoleKey.B)
                PageRings();

            if (command == ConsoleKey.C)
                PageDogs();

            if (command == ConsoleKey.D)
                PageBreeds();
        }


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
