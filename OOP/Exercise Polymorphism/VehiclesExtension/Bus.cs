using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {

        private const double AddConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, AddConsumption)
        {

        }
        public void DriveEmpty(double distance)
        {
            double fuelNeeded = distance * (FuelConsumptionInLitersPerKm - AddConsumption);

            if (FuelQuantity - fuelNeeded >= 0)
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                FuelQuantity -= fuelNeeded;
            }
            else Console.WriteLine($"{GetType().Name} needs refueling");
        }
    }
}
