using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        public const double ConsumptionModifier = 1.4;

        public Bus(double fuelQuantity, double fuelConsumptionInLPerKm, double tankCapacity) :
            base(fuelQuantity, fuelConsumptionInLPerKm, tankCapacity)
        {
        }
        public void DriveWithPeople(double distance)
        {
            double totalConsumptionPerTravel = distance * (FuelConsumptionInLPerKm + ConsumptionModifier);
            if (FuelQuantity >= totalConsumptionPerTravel)
            {
                FuelQuantity -= totalConsumptionPerTravel;
                Console.WriteLine($"Bus travelled {distance} km");
            }
            else
            {
                throw new ArgumentException("Bus needs refueling");
            }
        }
    }
}
