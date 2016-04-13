namespace TestProject.UTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sorting;
    using System;
    using System.Linq;
    using Sorting.Models;

    [TestClass]
    public class UnitTest
    {
        TravelRepository _repo = new TravelRepository();

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is no entry point in cards collection")]
        public void TestNoStartCard()
        {
            var noEntryCards = _repo.CreateCards(5);
            noEntryCards[0].CityFrom = noEntryCards[4].CityTo;

            CardHelpers.SetStartCard(noEntryCards);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "There is a gap in a cards list.")]
        public void TestMissingCard()
        {
            var missingCards = _repo.CreateCards(5).ToList();
            missingCards.RemoveAt(2);

            CardHelpers.SetRestCards(missingCards.ToArray());
        }

        [TestMethod]
        public void TestSorting()
        {
            var init = _repo.CreateCards(20);
            var copy = new TravelCard[init.Length];
            Array.Copy(init, copy, init.Length);
            
            CardHelpers.ShuffleCards(copy);

            CardHelpers.OrderCards(copy);

            CollectionAssert.AreEqual(init, copy);

        }
    }
}
