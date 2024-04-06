namespace Railway.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Railway;

    public class Tests
    {
        string train = "Sofia-Varna";
        private Queue<string> arrivalTrains;
            private Queue<string> departureTrains;
        private RailwayStation railwayStation;
        [SetUp]
        public void Setup()
        {
            railwayStation = new RailwayStation("station");
            arrivalTrains = new Queue<string>();
            departureTrains = new Queue<string>();
        }

        [Test]
        public void Constructor_HappyPath()
        {
            Assert.AreEqual("station",railwayStation.Name);
            Assert.AreEqual(0,railwayStation.ArrivalTrains.Count);
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);

        }
        [TestCase(null)]
        [TestCase(" ")]
        public void NameNullOrWhiteSpace_ThrowsEx(string incorrectName)
        {
            Exception ex = Assert.Throws<ArgumentException>(()=>railwayStation= new RailwayStation(incorrectName));
            Assert.AreEqual(ex.Message, "Name cannot be null or empty!");
        }

        [Test]
        public void ArrivalTrains_HappyPath()
        {
            Assert.AreEqual(railwayStation.ArrivalTrains,arrivalTrains);
        }
        [Test]
        public void DepartureTrains_HappyPath()
        {
            Assert.AreEqual(railwayStation.DepartureTrains, departureTrains);
        }
        [Test]
        public void NewArrivalOnBoard_HappyPath()
        {
            railwayStation.NewArrivalOnBoard($"{train}");
          //  Assert.AreEqual(1,railwayStation.ArrivalTrains.Count);
            Assert.AreEqual($"{train}", railwayStation.ArrivalTrains.Dequeue());
        }
        [Test]
        public void NewArrivalOnBoardCount_HappyPath()
        {
            arrivalTrains.Enqueue(train);
            Assert.AreEqual(arrivalTrains.Count,1);
        }

        [Test]
        public void ArrivedTrains_HappyPath()
        {
            railwayStation.NewArrivalOnBoard($"{train}");
            Assert.AreEqual( "There are other trains to arrive before Sofia-KN.",
                railwayStation.TrainHasArrived("Sofia-KN"));
            Assert.AreEqual($"{train} is on the platform and will leave in 5 minutes.",
                railwayStation.TrainHasArrived($"Sofia-Varna"));
            Assert.AreEqual(1, railwayStation.DepartureTrains.Count);
          Assert.AreEqual($"{train}",railwayStation.DepartureTrains.Dequeue());
           Assert.AreEqual(0,railwayStation.ArrivalTrains.Count);
        }
        [Test]
        public void TrainHasLeft_HappyPath()
        {
            railwayStation.NewArrivalOnBoard(train);
            railwayStation.TrainHasArrived(train);

            Assert.AreEqual(false, railwayStation.TrainHasLeft("Sofia-Burgas"));
            Assert.AreEqual(true, railwayStation.TrainHasLeft(train));
            Assert.AreEqual(0, railwayStation.DepartureTrains.Count);

        }
    }
}