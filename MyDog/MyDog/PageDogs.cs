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
            Console.WriteLine("b) Add new dog");
            Console.WriteLine("c) Update dog info..");
            Console.WriteLine("d) Delete dog");
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
            Console.Clear();
            Header("Delete dog");
            ShowAllDogsBrief();

            Console.Write("Which dog do you want to delete (please enter the id number)? ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int dogId))
            {
                WriteRed("Please enter the dog's id number");
                Console.ReadKey();
                DeleteDog();
            }

            bool exhibitorIdExists = _dataAccess.CheckIfDogIdExists(dogId);

            if (exhibitorIdExists == false)
            {
                WriteRed($"\nAn exhibitor with id number {dogId} doesn't exist.");
            }
            else
            {
                _dataAccess.RemoveDogFromExhibitorDog(dogId);
                _dataAccess.RemoveDog(dogId);

                WriteGreen("\nThe dog has been deleted!");
            }

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
            Console.Clear();
            Header("Add dog");

            var dog = new Dog();

            Console.Write("What is the name of the dog? ");
            dog.Name = Console.ReadLine();

            if (dog.Name.Trim() == "")
            {
                WriteRed("You have to enter a name for your dog!");
                AddDogBrief();
            }

            Console.Write("What is the breed of the dog? ");
            dog.Breed = Console.ReadLine();

            try
            {
                _dataAccess.CreateDog(dog);
                WriteGreen($"The dog {dog.Name} ({dog.Breed}) has been added!");

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCouldn't create the dog because the breed doesn't exist.");
                Console.WriteLine("Please create a new breed first.");
                Console.ResetColor();
            }

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

        private void ShowAllDogsBrief()
        {
            List<Dog> listOfDogs = new List<Dog>();

            listOfDogs = _dataAccess.GetAllDogs();

            foreach (var dog in listOfDogs)
            {
                Console.Write($"*{dog.Id}".PadRight(10));
                Console.Write(dog.Name.PadRight(20));
                Console.WriteLine(dog.Breed);
            }
        }

        private Dog AddDogBrief()
        {
            var dog = new Dog();

            Console.Write("What is the name of the dog? ");
            dog.Name = Console.ReadLine();

            if (dog.Name.Trim() == "")
            {
                WriteRed("You have to enter a name for your dog!");
                AddDogBrief();
            }

            Console.Write("What is the breed of the dog? ");
            dog.Breed = Console.ReadLine();

            try
            {
                _dataAccess.CreateDog(dog);
                WriteGreen($"The dog {dog.Name} ({dog.Breed}) has been added!");
                return dog;

            }
            catch (Exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCouldn't create the dog because the breed doesn't exist.");
                Console.WriteLine("Please create a new breed first.");
                Console.ResetColor();
                return null;
            }
        }
    }
}
