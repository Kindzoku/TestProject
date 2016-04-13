namespace TestProject.Sorting
{
    using System;
    using Models;

    public class CardHelpers
    {
        /// <summary>
        /// Shuffles cards list
        /// </summary>
        /// <param name="cards">Cards collection</param>
        public static void ShuffleCards(TravelCard[] cards)
        {
            Random rnd = new Random();

            int n = cards.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + (int)(rnd.NextDouble() * (n - i));
                TravelCard t = cards[r];
                cards[r] = cards[i];
                cards[i] = t;
            }
        }

        public static void OrderCards(TravelCard[] cards)
        {
            SetStartCard(cards);

            SetRestCards(cards);
        }

        /// <summary>
        /// Searches for an entry point for cards collection. Places the match in a first position.
        /// </summary>
        /// <param name="cards">Cards collection</param>
        /// <param name="cur">Current card to compare with</param>
        public static void SetStartCard(TravelCard[] cards, int cur = 0)
        {
            if (cur >= cards.Length) throw new InvalidOperationException("There is no entry point in cards collection");
            for (int i = 0; i < cards.Length; i++)
            {
                if (i == cur) continue;

                if (cards[cur].CityFrom == cards[i].CityTo)
                {
                    SetStartCard(cards, cur + 1);
                    return;
                }
            }
            TravelCard tmp = cards[0];
            cards[0] = cards[cur];
            cards[cur] = tmp;
        }

        /// <summary>
        /// Setting rest of the cards in collection.
        /// </summary>
        /// <param name="cards">Cards collection</param>
        public static void SetRestCards(TravelCard[] cards)
        {
            int last = 1;
            for (int i = last; i < cards.Length; i++)
            {
                if (cards[i].CityFrom == cards[last - 1].CityTo)
                {
                    TravelCard tmp = cards[last];
                    cards[last] = cards[i];
                    cards[i] = tmp;

                    i = last++;
                }
            }
            if (last < cards.Length) throw new InvalidOperationException("There is a gap in a cards list.");
        }

        public static void ShowCollection(TravelCard[] cards)
        {
            Console.WriteLine("Current collection state:");
            Console.WriteLine(string.Join(", ", (object[])cards));
            Console.WriteLine(Environment.NewLine);
        }
    }
}
