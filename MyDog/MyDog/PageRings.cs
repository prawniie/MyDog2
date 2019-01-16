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

            Console.WriteLine("a) See all rings");    // Agda 87 klickade på R när hon skulle göra ett val, då sa programmet åt 
            Console.WriteLine("b) Add new ring");     // henne att det inte finns en ring med id 0 ? Agda är förvirrad.
            Console.WriteLine("c) Update ring info..");
            Console.WriteLine("d) Delete ring");
            Console.WriteLine("e) Go back to main menu");

            ConsoleKey command = Console.ReadKey(true).Key;    // Om man klickar på annat än de valen i menyn så stängs programmet av.
                                                               // Kanske ha en command == ConsoleKey.Escape som stänger av är mer passande.
            if (command == ConsoleKey.A)                       // Sedan en else sats som inte tillåter feltryckningar.
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
            Console.Clear();
            Header("Delete ring");

            ShowAllRingsBrief();

            Console.Write("Which ring do you want to delete (please enter the id number)? ");

            string input = Console.ReadLine();

            if (!int.TryParse(input, out int ringId))
            {
                WriteRed("Please enter the ring's id number");
                Console.ReadKey();                                //Om Id't på Agda, 87's ring är abc så dör hela programmet
                DeleteRing();
            }

            bool ringIdExists = _dataAccess.CheckIfRingIdExists(ringId);

            if (ringIdExists == false)
            {
                WriteRed($"\nA ring with id number {ringId} doesn't exist.");
            }
            else
            {
                _dataAccess.RemoveRingFromRingBreed(ringId);
                _dataAccess.RemoveRingFromRingExhibitor(ringId);
                _dataAccess.RemoveRing(ringId);

                WriteGreen("\nThe ring has been deleted!");
            }

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
            Console.Clear();
            Header("Add ring");

            var ring = new Ring();
            Console.Write("Enter the number of the new ring: ");
            ring.Number = int.Parse(Console.ReadLine());

            bool ringExists = _dataAccess.CheckIfRingExists(ring);

            if(ringExists == false)
            {
                _dataAccess.CreateRing(ring);
                WriteGreen($"\nThe ring {ring.Number} was created!");
            }
            else
            {
                WriteRed("\nThe ring already exists!");
            }

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

        private void ShowAllRingsBrief()
        {
            List<Ring> listOfRings = new List<Ring>();

            listOfRings = _dataAccess.GetAllRings();

            Console.Clear();

            Header("Rings");
            foreach (var ring in listOfRings)
            {
                Console.WriteLine($"* Ring number {ring.Number}");
            }
        }
    }
}
