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
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            string[] busInfo = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            int comandsNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < comandsNumber; i++)
            {
                try
                {
                    string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    switch (command[0])
                    {
                        case "Drive":
                            if (command[1] == "Car")
                            {
                                car.Drive(double.Parse(command[2]));
                            }
                            else if (command[1] == "Truck")
                            {
                                truck.Drive(double.Parse(command[2]));
                            }
                            else if (command[1] == "Bus")
                            { bus.DriveWithPeople(double.Parse(command[2])); }
                            break;
                        case "Refuel":
                            if (command[1] == "Car")
                            {
                                car.Refuel(double.Parse(command[2]));
                            }
                            else if (command[1] == "Truck")
                            {
                                truck.Refuel(double.Parse(command[2]));
                            }
                            else if (command[1] == "Bus")
                            {
                                bus.Refuel(double.Parse(command[2]));
                            }
                            break;
                        case "DriveEmpty": bus.Drive(double.Parse(command[2])); break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
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