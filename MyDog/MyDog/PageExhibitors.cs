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

            Console.WriteLine("a) See all exhibitors..");
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
            throw new NotImplementedException();
        }

        private void UpdateExhibitor()
        {
            throw new NotImplementedException();
        }

        private void AddExhibitor()
        {
            throw new NotImplementedException();
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
                Console.Write($"0{exhibitor.PhoneNumber.ToString()}".PadRight(20));
                Console.WriteLine(exhibitor.EmailAdress);
            }

            Console.WriteLine("\nPress any key to go back to main menu");
            Console.ReadKey();
            PageMainMenu();
        }
    }
}
