namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Runtime.ConstrainedExecution;

    [TestFixture]
    public class CarManagerTests
    {
        private const string Make = "BMW";
        private const string Model = "e90";
        private const double FuelConsumption = 9.00;
        private const double FuelCapacity = 78;
        private Car BMW;
        [SetUp]
        public void SetUp()
        {
             BMW = new Car(Make,Model,FuelConsumption,FuelCapacity);  
        }
        [Test]
        public void Ctor_CreateNewInstance_CorrectParameters()
        {
            Car car = new Car(Make, Model, FuelConsumption, FuelCapacity);
            Assert.IsNotNull(car);
            Assert.AreEqual(Make, car.Make);
            Assert.AreEqual(Model, car.Model);
            Assert.AreEqual(FuelConsumption, car.FuelConsumption);
            Assert.AreEqual(FuelCapacity, car.FuelCapacity);
            Assert.AreEqual(car.FuelAmount, 0);
        }
        [Test]
        public void NullMake_ThrowsEx()
        {
          Exception ex =Assert.Throws<ArgumentException> (()=> new Car(null, Model, FuelConsumption, FuelCapacity));
        }
        [Test]
        public void EmptyMake_ThrowsEx()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(String.Empty, Model, FuelConsumption, FuelCapacity));
        }
        [Test]
        public void NullModel_ThrowsEx()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(Make, null, FuelConsumption, FuelCapacity));
        }
        [Test]
        public void EmptyModel_ThrowsEx()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(Make, String.Empty, FuelConsumption, FuelCapacity));
        }
        [Test]
        public void NegativeFuelConsimation_ThrowsEx()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(Make, Model, -70, FuelCapacity));
            Exception ex1 = Assert.Throws<ArgumentException>(() => new Car(Make, Model, 0, FuelCapacity));
        }
        [Test]
        public void NegativeFuelCapacity_ThrowsEx()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => new Car(Make, Model, FuelConsumption, -10));
            Exception ex1 = Assert.Throws<ArgumentException>(() => new Car(Make, Model, FuelConsumption, 0 ));
        }
        [Test]
        public void NegativeFuelToRefuel_ThrowsEx()
        {
           Exception ex = Assert.Throws<ArgumentException>(()=> BMW.Refuel(-34));

        }
        [Test]
        public void ZeroFuelToRefuel_ThrowsEx()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => BMW.Refuel(0));

        }
        [Test]
        public void Refuel_HappyPath()
        {
            double fuelAmount = FuelCapacity - 1;
            BMW.Refuel(fuelAmount);
            Assert.AreEqual(BMW.FuelAmount, fuelAmount);
        }
        [Test]
        public void Refuel_TankOverFlow()
        {
            double fuelAmount = FuelCapacity + 1;
            BMW.Refuel(fuelAmount);
            Assert.AreEqual(BMW.FuelAmount, FuelCapacity);
        }

        [Test]
        public void Drive_HappyPath()
        {
            double distance = 25;
            BMW.Refuel(FuelCapacity);
            double fuelNeeded = (distance / 100) * FuelConsumption;
            double expectedFuelAmount = BMW.FuelAmount - fuelNeeded;
           BMW.Drive(distance);
            Assert.AreEqual(expectedFuelAmount, BMW.FuelAmount);
        }
        [Test]
        public void Drive_ThorwsEx()
        {
            double distance = 25;
            double fuelNeeded = (distance / 100) * FuelConsumption;
            double expectedFuelAmount = BMW.FuelAmount - fuelNeeded;
            Assert.Throws<InvalidOperationException>(()=>BMW.Drive((distance)));
        }
    }
}