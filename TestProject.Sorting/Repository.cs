namespace TestProject.Sorting
{
    using Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    public class TravelRepository
    {
        public TravelCard[] CreateCards(int count)
        {
            string appFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string cityList = Path.Combine(appFolder, "city_list.txt");
            string[] cities = File.ReadAllLines(cityList);

            TravelCard[] cards = new TravelCard[count];

            Random rnd = new Random();
            int[] rndValues = new int[count];

            Func<int, int> rndCityIndex = (cityNo) => {
                int rndValue = rnd.Next(cities.Length);
                while (rndValues.Contains(rndValue))
                {
                    rndValue = rnd.Next(cities.Length);
                }
                rndValues[cityNo] = rndValue;
                return rndValue;
            };

            var firstCity = cities[rndCityIndex(0)];
            for (var i = 0; i < count; i++)
            {
                var nextCity = cities[rndCityIndex(i)];
                if (i == 0)
                {
                    cards[i] = new TravelCard(firstCity, nextCity);
                    continue;
                }
                cards[i] = new TravelCard(cards[i - 1].CityTo, nextCity);
            }

            return cards;
        }
    }
}
