using System;

namespace CarManufacturer;

public class StartUp
{
    public static void Main(string[] args)
    {
        string info = string.Empty;
        List<Tires[]> tiresList = new();
        while ((info = Console.ReadLine()) != "No more tires")
        {
            string[] tires = info.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int firstTireYear = int.Parse(tires[0]);
            double firstTirePressure = double.Parse(tires[1]);
            int secondTireYear = int.Parse(tires[2]);
            double secondTirePressure = double.Parse(tires[3]);
            int thirdTiresear = int.Parse(tires[4]);
            double thirdTirePressure = double.Parse(tires[5]);
            int fourthTireYear = int.Parse(tires[6]);
            double fourthTirePressure = double.Parse(tires[7]);

            Tires firstTire = new Tires(firstTireYear, firstTirePressure);
            Tires secondTire = new Tires(secondTireYear, secondTirePressure);
            Tires thirdTire = new Tires(thirdTiresear, thirdTirePressure);
            Tires fourthTire = new Tires(fourthTireYear, fourthTirePressure);
            Tires[] carTires = new Tires[4]
           {
                firstTire,
                secondTire,
                thirdTire,
                fourthTire
           };
            tiresList.Add(carTires);
        }
        List<Engine> enginesList = new();
        string engineInfo = string.Empty;
        while ((engineInfo = Console.ReadLine()) != "Engines done")
        {
            string[] lines = engineInfo.Split();
            int horsePower = int.Parse(lines[0]);
            double cubicCapacity = double.Parse(lines[1]);
            Engine currentEngine = new Engine(horsePower, cubicCapacity);
            enginesList.Add(currentEngine);
        }
        string input = string.Empty;
        List<Car> carList = new();
        while ((input = Console.ReadLine()) != "Show special")
        {
            string[] lines = input.Split();
            string make = lines[0];
            string model = lines[1];
            int year = int.Parse(lines[2]);
            double fuelQuantity = double.Parse(lines[3]);
            double fuelConsumption = double.Parse(lines[4]);
            int engineIndex = int.Parse(lines[5]);
            int tiresIndex = int.Parse(lines[6]);
            Engine currentEngine = enginesList[engineIndex];
            Tires[] currentTires = tiresList[tiresIndex];
            Car currentCar = new Car(make,model,year,fuelQuantity, fuelConsumption, currentEngine, currentTires);
            carList.Add(currentCar);
        }
        List<Car> filteredCars = carList.Where(x => x.Year >= 2017)
             .Where(x => x.Engine.HorsePower > 330)
             .Where(x => x.Tire.Sum(p => p.Pressure) >= 9 && x.Tire.Sum(p => p.Pressure) <= 10)
             .ToList();

        foreach (var filteredCar in filteredCars)
        {
            filteredCar.Drive(20);
            Console.WriteLine(filteredCar.WhoAmI());
        }
    }
}