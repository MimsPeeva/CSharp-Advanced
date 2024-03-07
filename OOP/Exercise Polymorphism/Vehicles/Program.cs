namespace Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            string[] truckInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));
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
                            break;
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
                Console.WriteLine(car.ToString());
                    Console.WriteLine(truck.ToString());
        }
    }
}
/*
Car 15 0.3
Truck 100 0.9
4
Drive Car 9
Drive Car 30
Refuel Car 50
Drive Truck 10

Car 30.4 0.4
Truck 99.34 0.9
5
Drive Car 500
Drive Car 13.5
Refuel Truck 10.300
Drive Truck 56.2 
Refuel Car 100.2
 */