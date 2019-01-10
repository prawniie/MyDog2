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

        

        private void PageDogs()
        {
            Console.Clear();

            Header("Dogs");

            Console.WriteLine("See all competing dogs..");
            Console.WriteLine("Add new dog..");
            Console.WriteLine("Update dog info..");
            Console.WriteLine("Delete dog..");

            Console.WriteLine();
        }

        private void PageRings()
        {
            Console.Clear();

            Header("Rings");

            Console.WriteLine("See all rings..");
            Console.WriteLine("Add new ring..");
            Console.WriteLine("Update ring info..");
            Console.WriteLine("Delete ring..");

            Console.WriteLine();
        }

        private void PageExhibitors()
        {
            Console.Clear();

            Header("Exhibitors");

            Console.WriteLine("See all exhibitors..");
            Console.WriteLine("Add new exhibitor..");
            Console.WriteLine("Update exhibitor info..");
            Console.WriteLine("Delete exhibitor..");

            Console.WriteLine();
        }

        private void Header(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
