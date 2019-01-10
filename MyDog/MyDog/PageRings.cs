using System;
using System.Collections.Generic;
using System.Text;

namespace MyDog
{
    partial class App

    {
        private void PageRings()
        {
            Console.Clear();

            Header("Rings");

            Console.WriteLine("a) See all rings");
            Console.WriteLine("b) Add new ring..");
            Console.WriteLine("c) Update ring info..");
            Console.WriteLine("d) Delete ring..");
            Console.WriteLine("e) Go back to main menu");

            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
                ShowAllRings();

            if (command == ConsoleKey.B)
                AddRing();

            if (command == ConsoleKey.C)
                UpdateRing();

            if (command == ConsoleKey.D)
                DeleteRing();

            if (command == ConsoleKey.E)
                PageMainMenu();

            Console.WriteLine();

            Console.WriteLine();
        }

        private void DeleteRing()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

        }

        private void UpdateRing()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

        }

        private void AddRing()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

        }

        private void ShowAllRings()
        {
            List<Ring> listOfRings = new List<Ring>();

            listOfRings = _dataAccess.GetAllRings();

            Console.Clear();

            Header("Rings");
            foreach (var ring in listOfRings)
            {
                Console.WriteLine($"* Ring number {ring.Number}");
            }

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }
    }
}
