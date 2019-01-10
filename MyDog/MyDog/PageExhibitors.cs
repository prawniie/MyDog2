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

            Console.WriteLine("a) See all exhibitors");
            Console.WriteLine("b) Add new exhibitor..");
            Console.WriteLine("c) Update exhibitor info..");
            Console.WriteLine("d) Delete exhibitor..");
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
            Console.WriteLine("\nFeature will be implemented in the following sprint..");

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();

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
