using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
    [TestFixture()]
    public class FlightTest
    {
        private readonly DateTime dateFlightLeaves = new DateTime(2012, 3, 13, 7, 0, 0);
        private readonly DateTime dateFlightReturns = new DateTime(2012, 3, 14, 7, 0, 0);
        private readonly int someMiles = 1000;

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(dateFlightLeaves, dateFlightReturns, someMiles);
            Assert.IsNotNull(target);
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayApart()
        {
            var target = new Flight((new DateTime(2012, 1, 1, 7, 0, 0)), (new DateTime(2012, 1, 2, 7, 0, 0)), 100);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayApart()
        {
            var target = new Flight((new DateTime(2012, 1, 1, 7, 0, 0)), (new DateTime(2012, 1, 3, 7, 0, 0)), 200);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDaysApart()
        {
            var target = new Flight((new DateTime(2012, 1, 1, 7, 0, 0)), (new DateTime(2012, 1, 11, 7, 0, 0)), 500);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDateRange()
        {
            new Flight((new DateTime(2012, 1, 10, 7, 0, 0)), (new DateTime(2012, 1, 9, 7, 0, 0)), 100);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMilage()
        {
            new Flight((new DateTime(2012, 1, 10, 7, 0, 0)), (new DateTime(2012, 1, 19, 7, 0, 0)), -100);
        }


    }
}