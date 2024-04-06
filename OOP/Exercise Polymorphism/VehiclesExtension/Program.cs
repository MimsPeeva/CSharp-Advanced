using VehiclesExtension;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]),
                double.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            int comandsNumber = int.Parse(Console.ReadLine());
            List<Vehicle> vehicles = new()
            {
                car,
                truck,
                bus
            };

            for (int i = 0; i < comandsNumber; i++)
            {
                string[] commandDetails = Console.ReadLine()!.Split();
                string command = commandDetails[0];
                string vehicleType = commandDetails[1];

                Vehicle vehicle = vehicles.Find(v => v.GetType().Name == vehicleType)!;
                if (command == "Drive") vehicle.Drive(double.Parse(commandDetails[2]));
                else if (command == "Refuel") vehicle.Refuel(double.Parse(commandDetails[2]));
                else if (command == "DriveEmpty")
                    (vehicle as Bus)!.DriveEmpty(double.Parse(commandDetails[2])); 

            }

            foreach (Vehicle vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}

/*
Car 30 0.04 70
Truck 100 0.5 300
Bus 40 0.3 150
8
Refuel Car -10
Refuel Truck 0
Refuel Car 10
Refuel Car 300
Drive Bus 10
Refuel Bus 1000
DriveEmpty Bus 100
Refuel Truck 1000
 */