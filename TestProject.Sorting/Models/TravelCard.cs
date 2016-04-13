using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Sorting.Models
{
    public class TravelCard
    {
        public TravelCard(string cityFrom, string cityTo)
        {
            CityFrom = cityFrom;
            CityTo = cityTo;
        }

        public string CityFrom { get; set; }

        public string CityTo { get; set; }

        public override string ToString()
        {
            return string.Format("{0} => {1}", CityFrom, CityTo);
        }
    }
}
