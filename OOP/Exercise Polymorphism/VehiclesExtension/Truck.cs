using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AddConsumption = 1.6;
        private const double TruckFuelLeak = 0.05;

        public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsumptionInLitersPerKm, tankCapacity, AddConsumption)
        {

        }

        public override void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }

            if (FuelQuantity + fuel > TankCapacity) 
                Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            else FuelQuantity += fuel * (1 - TruckFuelLeak);
        }
    }
}
