using System;
using System.Collections.Generic;
using System.Text;

namespace MyDog
{
    partial class App
    {
        private void PageDogs()
        {
            Console.Clear();

            Header("Dogs");

            Console.WriteLine("a) See all dogs");
            Console.WriteLine("b) Add new dog..");
            Console.WriteLine("c) Update dog info..");
            Console.WriteLine("d) Delete dog..");
            Console.WriteLine("e) Go back to main menu");

            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
                ShowAllDogs();

            if (command == ConsoleKey.B)
                AddDog();

            if (command == ConsoleKey.C)
                UpdateDog();

            if (command == ConsoleKey.D)
                DeleteDog();

            if (command == ConsoleKey.E)
                PageMainMenu();

            Console.WriteLine();
        }

        private void DeleteDog()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }

        private void UpdateDog()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

        }

        private void AddDog()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

        }

        private void ShowAllDogs()
        {
            List<Dog> listOfDogs = new List<Dog>();

            listOfDogs = _dataAccess.GetAllDogs();

            Console.Clear();

            Header("Dogs");
            foreach (var dog in listOfDogs)
            {
                Console.Write($"* {dog.Name}".PadRight(20));
                Console.WriteLine(dog.Breed);
            }

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }
    }
}
