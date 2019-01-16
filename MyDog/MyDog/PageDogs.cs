using System;
using System.Collections.Generic;
using System.Linq;
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
                AddDogPage();

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

        private void AddDogPage()
        {
            Console.Clear();
            Header("Add dog");

            Console.WriteLine("To be able to add a new dog, you need to do the following choice: ");
            Console.WriteLine("a) Use existing exhibitor");
            Console.WriteLine("b) Add a new exhibitor");
            Console.WriteLine("c) Go back to main menu");

            ConsoleKey command = Console.ReadKey(true).Key;

            Exhibitor exhibitor = new Exhibitor();

            if (command == ConsoleKey.A)
            {
                exhibitor = GetExhibitorFromList();
                AddDog(exhibitor);
            }
            
            if(command == ConsoleKey.B)
                AddExhibitor();

            if (command == ConsoleKey.C)
                PageMainMenu();

            

        }

        private void AddDog(Exhibitor exhibitor)
        {
            do
            {
                Dog dog = new Dog();

                Console.WriteLine("\nAdd dog");
                Console.Write("Enter name of your dog: ");
                string name = Console.ReadLine();

                Console.Write("Enter breed of your dog: ");
                string breed = Console.ReadLine();

                dog.Name = name;
                dog.Breed = breed;
                exhibitor.Dogs.Add(dog);

                Console.Write("Do you want to add another dog (yes/no)? ");
                string input = Console.ReadLine();

                if (input.ToLower() == "no")
                    break;

            } while (true);

            _dataAccess.CreateDogs(exhibitor);

            //try
            //{
            //    _dataAccess.CreateDog(dog);
            //    WriteGreen($"The dog {dog.Name} ({dog.Breed}) has been added!");

            //}
            //catch (Exception)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine("\nCouldn't create the dog because the breed doesn't exist.");
            //    Console.WriteLine("Please create a new breed first.");
            //    Console.ResetColor();
            //}

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }

        private Exhibitor GetExhibitorFromList()
        {
            List<Exhibitor> listOfExhibitors = new List<Exhibitor>();

            listOfExhibitors = _dataAccess.GetAllExhibitors();

            List<Dog> listOfExhibitorsDogs = new List<Dog>();


            Console.Clear();

            Header("Exhibitors");

            Console.WriteLine("NAME".PadRight(40) + "PHONE NUMBER".PadRight(20) + "EMAIL ADDRESS\n");

            foreach (var exhibitor in listOfExhibitors)
            {
                Console.Write($"{exhibitor.Id}: {exhibitor.FirstName} {exhibitor.LastName}".PadRight(40));
                Console.Write($"{exhibitor.PhoneNumber}".PadRight(20));
                Console.WriteLine(exhibitor.EmailAdress);

                listOfExhibitorsDogs = _dataAccess.GetAllDogsByExhibitorId(exhibitor);
                Console.WriteLine($"Dogs: {string.Join(',', listOfExhibitorsDogs.Select(d => d.Name))}");
                Console.WriteLine("__________________________________________________________________________________________________\n");
            }

            Console.Write("Which exhibitor do you want to use (enter id number)? ");
            int exhibitorId = int.Parse(Console.ReadLine());

            Exhibitor ex = _dataAccess.GetExhibitorById(exhibitorId);

            return ex;

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
