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

            Console.WriteLine("See all dogs");
            Console.WriteLine("Add new dog..");
            Console.WriteLine("Update dog info..");
            Console.WriteLine("Delete dog..");

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
            throw new NotImplementedException();
        }

        private void UpdateDog()
        {
            throw new NotImplementedException();
        }

        private void AddDog()
        {
            throw new NotImplementedException();
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
