using System.Collections.Generic;

namespace Raw_Data;
public class StartUp
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Car> carsList = new();
        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            //"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} {tire1Pressure} {tire1Age}
            //{tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
            string model = input[0];
            int engineSpeed = int.Parse(input[1]);
            int enginePower = int.Parse(input[2]);
            int cargoWeight = int.Parse(input[3]);
            string cargoType = input[4];
            double tire1Pressure = double.Parse(input[5]);
            int tire1Age = int.Parse(input[6]);
            double tire2Pressure = double.Parse(input[7]);
            int tire2Age = int.Parse(input[8]);
            double tire3Pressure = double.Parse(input[9]);
            int tire3Age = int.Parse(input[10]);
            double tire4Pressure = double.Parse(input[11]);
            int tire4Age = int.Parse(input[12]);
            Engine currEngine = new Engine(engineSpeed,enginePower);
            Tire[] tires =
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure),
                };
            Cargo currCargo = new Cargo(cargoType, cargoWeight);
            Car currCar = new Car(model, currEngine,currCargo, tires);
            carsList.Add(currCar);
        }
        string command = Console.ReadLine();
        string[] filteredCars;
        if (command == "fragile")
        {
            filteredCars = carsList.Where(car => car.Cargo.Type == "fragile" && car.Tire.Any(p=>p.Pressure<1))
                .Select(p => p.Model)
                .ToArray();
        }
        else //if (command == "flammable")
        {
            filteredCars = carsList.Where(car => car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                .Select(p => p.Model)
                .ToArray();
        }
        Console.WriteLine(string.Join(Environment.NewLine, filteredCars));
    } 
}
/*
2
ChevroletAstro 200 180 1000 fragile 1.3 1 1.5 2 1.4 2 1.7 4
Citroen2CV 190 165 1200 fragile 0.9 3 0.85 2 0.95 2 1.1 1
fragile
*/