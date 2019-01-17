using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace MyDog
{
    partial class App
    {

        DataAccess _dataAccess = new DataAccess();

        public void Run()
        {                                            
            WriteLogo();                             
            PageMainMenu();                         
                                                   
        }

        private void WriteLogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine();
            Console.WriteLine(@"                                                        __  __       _____              ");
            Console.WriteLine(@"                                                       |  \/  |     |  __ \             ");
            Console.WriteLine(@"                                                       | \  / |_   _| |  | | ___   __ _ ");
            Console.WriteLine(@"                                                       | |\/| | | | | |  | |/ _ \ / _` |");
            Console.WriteLine(@"                                                       | |  | | |_| | |__| | (_) | (_| |");
            Console.WriteLine(@"                                                       |_|  |_|\__, |_____/ \___/ \__, |");
            Console.WriteLine(@"                                                                __/ |              __/ |");
            Console.WriteLine(@"                                                               |___/              |___/ ");
            Console.WriteLine();

            Console.ResetColor();
            Console.ReadKey();
            Thread.Sleep(2000);
        }

        private void PageMainMenu()
        {
            Console.Clear();
            Header("Menu");
            Console.WriteLine("a) Exhibitors");                                             // (kritisk programmerare) För mycket tomma funktioner.
            Console.WriteLine("b) Rings");
            Console.WriteLine("c) Dogs");
            Console.WriteLine("d) Breeds");

            Console.WriteLine("\n\nPress 'esc' to quit");

            ConsoleKey command = Console.ReadKey(true).Key;                                

            if (command == ConsoleKey.A)
                PageExhibitors();

            else if (command == ConsoleKey.B)
                PageRings();

            else if (command == ConsoleKey.C)
                PageDogs();

            else if (command == ConsoleKey.D)
                PageBreeds();

            else if (command == ConsoleKey.Escape)
                Console.WriteLine("\nShutting down the app..\n");

            else
            {
                WriteRed("You have to press the A,B,C or D button to get started!");
                Console.ReadKey();
                PageMainMenu();
            }
        }                                                         


        private void Header(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text.ToUpper());
            Console.WriteLine();
            Console.ResetColor();
        }

        private void WriteGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private void WriteRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
