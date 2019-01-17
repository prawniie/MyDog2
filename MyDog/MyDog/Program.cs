using System;

namespace MyDog
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            app.Run();

            //TODO: lägga till try catch när man försöker ta bort något som har en constraint, tex när man försöker ta bort en ras (när de tfinns hundar av den rasen, ska komma upp rött meddelande som informerar om att det ej går)

            //varningsmeddelande när man ska ta bort grejer

            //TODO: lägga till de sista uppdateringsfunktionerna för rings och exhibitor

        }
    }
}
