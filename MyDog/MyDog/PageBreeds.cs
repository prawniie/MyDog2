using System;
using System.Collections.Generic;
using System.Text;

namespace MyDog
{
    partial class App
    {
        private void PageBreeds()
        {
            Console.Clear();

            Header("Breeds");
            Console.WriteLine("a) See all breeds");
            Console.WriteLine("b) Add breed..");
            Console.WriteLine("c) Update breed info..");
            Console.WriteLine("d) Delete breed..");
            Console.WriteLine("e) Go back to main menu");

            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
                ShowAllBreeds();

            if (command == ConsoleKey.B)
                AddBreed();

            if (command == ConsoleKey.C)
                UpdateBreed();

            if (command == ConsoleKey.D)
                DeleteBreed();

            if (command == ConsoleKey.E)
                PageMainMenu();

            Console.WriteLine();
        }

        private void DeleteBreed()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }

        private void UpdateBreed()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }

        private void AddBreed()
        {
            Console.Clear();
            Header("Add new breed");

            Breed breed = new Breed();
            Console.Write("What is the name of the breed? ");
            breed.Name = Console.ReadLine();

            bool breedExistsInDatabase = _dataAccess.CheckIfBreedExists(breed);

            if(breedExistsInDatabase == false)
            {
                _dataAccess.CreateBreed(breed);
                WriteGreen($"The breed {breed.Name} has been added!");
            }
            else
            {
               WriteRed($"The breed {breed.Name} already exists!");
            }

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }

        private void ShowAllBreeds()
        {
            List<Breed> listOfBreeds = new List<Breed>();

            listOfBreeds = _dataAccess.GetAllBreeds();

            Console.Clear();

            //var listOfBreedsSorted = listOfBreeds.Select(b => b.Name).ToList();

            Header("Breeds");
            foreach (var breed in listOfBreeds)
            {
                Console.WriteLine($"* {breed.Name}");
            }

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

        }
    }
}
