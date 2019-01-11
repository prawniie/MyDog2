using System;
using System.Collections.Generic;
using System.Text;

namespace MyDog
{
    partial class App
    {
        private void PageExhibitors()
        {
            Console.Clear();

            Header("Exhibitors");

            Console.WriteLine("a) Show all exhibitors");
            Console.WriteLine("b) Add new exhibitor");
            Console.WriteLine("c) Update exhibitor info..");
            Console.WriteLine("d) Delete exhibitor");
            Console.WriteLine("e) Go back to main menu");

            ConsoleKey command = Console.ReadKey(true).Key;

            if (command == ConsoleKey.A)
                ShowAllExhibitors();

            if (command == ConsoleKey.B)
                AddExhibitor();

            if (command == ConsoleKey.C)
                UpdateExhibitor();

            if (command == ConsoleKey.D)
                DeleteExhibitor();

            if (command == ConsoleKey.E)
                PageMainMenu();

            Console.WriteLine();
        }

        private void DeleteExhibitor()
        {
            Console.Clear();
            Header("Delete exhibitor");

            ShowAllExhibitorsBrief();

            Console.Write("Which exhibitor do you want to delete (please enter the id number)? ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int exhibitorId))
            {
                WriteRed("Please enter the exhibitor's id number");
                Console.ReadKey();
                DeleteExhibitor();
            }

            bool exhibitorIdExists = _dataAccess.CheckIfExhibitorIdExists(exhibitorId);

            if (exhibitorIdExists == false)
            {
                WriteRed($"\nAn exhibitor with id number {exhibitorId} doesn't exist.");
            }
            else
            {
                _dataAccess.RemoveExhibitorFromRingExhibitor(exhibitorId);
                _dataAccess.RemoveExhibitorFromExhibitorDog(exhibitorId);
                _dataAccess.RemoveExhibitor(exhibitorId);

                WriteGreen("\nThe exhibitor has been deleted!");
            }

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

        }

        private void ShowAllExhibitorsBrief()
        {
            List<Exhibitor> listOfExhibitors = new List<Exhibitor>();

            listOfExhibitors = _dataAccess.GetAllExhibitors();

            foreach (var exhibitor in listOfExhibitors)
            {
                Console.Write($"{exhibitor.Id}* ".PadRight(5));
                Console.Write(exhibitor.FirstName.PadRight(15));
                Console.Write(exhibitor.LastName.PadRight(20));
                Console.Write($"{exhibitor.PhoneNumber}".PadRight(20));
                Console.WriteLine(exhibitor.EmailAdress);
            }
        }

        private void UpdateExhibitor()
        {
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

        }

        private void AddExhibitor()
        {
            Console.Clear();
            Header("Add exhibitor");

            var exhibitor = new Exhibitor();
            Console.Write("Enter first name: ");
            exhibitor.FirstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            exhibitor.LastName = Console.ReadLine();

            Console.Write("Enter phone number: ");
            exhibitor.PhoneNumber = Console.ReadLine();

            Console.Write("Enter email adress: ");
            exhibitor.EmailAdress = Console.ReadLine();

            _dataAccess.CreateExhibitor(exhibitor);

            //Lägg till att man kan lägga till hundar också, vilket sedan uppdateras i hunddatabasen

            do
            {
                Dog dog = AddDogBrief();
                exhibitor.Dogs.Add(dog);

                Console.Write("Do you want to add another dog (yes/no)? ");
                string input = Console.ReadLine();

                if (input.ToLower() == "no")
                    break;

            } while (true);
            

            WriteGreen($"\n{exhibitor.FirstName} {exhibitor.LastName} has been added!");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }

        private void ShowAllExhibitors()
        {
            List<Exhibitor> listOfExhibitors = new List<Exhibitor>();

            listOfExhibitors = _dataAccess.GetAllExhibitors();

            Console.Clear();

            Header("Exhibitors");
            foreach (var exhibitor in listOfExhibitors)
            {
                Console.Write($"{exhibitor.Id}* ".PadRight(5));
                Console.Write(exhibitor.FirstName.PadRight(15));
                Console.Write(exhibitor.LastName.PadRight(20));
                Console.Write($"{exhibitor.PhoneNumber}".PadRight(20));
                Console.WriteLine(exhibitor.EmailAdress);
            }

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }
    }
}
