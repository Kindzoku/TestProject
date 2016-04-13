namespace TestProject.Sorting
{
    using System;
    using Models;

    class Program
    {
        static void Main(string[] args)
        {
            int cardsCount = 0;
            Console.WriteLine("Please, enter the number of cards to generate.");
            do
            {
                if(!int.TryParse(Console.ReadLine(), out cardsCount))
                {
                    Console.WriteLine("Integer value is required!");
                }
            } while (cardsCount == 0);
            TravelRepository _repo = new TravelRepository();
            var cards = _repo.CreateCards(3);

            CardHelpers.ShuffleCards(cards);

            CardHelpers.ShowCollection(cards);

            try
            {
                CardHelpers.OrderCards(cards);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            CardHelpers.ShowCollection(cards);

            Console.ReadKey();
        }
    }
}
