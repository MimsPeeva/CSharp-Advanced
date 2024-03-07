using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double increasedConsumation = 1.6;
        private const double truckerFactor = 0.95;

        public Truck(double fuelQuantity, double fuelConsumptionInLPerKm, double tankCapacity) :
            base(fuelQuantity, fuelConsumptionInLPerKm+increasedConsumation, tankCapacity)
        {
        }

        public override void Refuel(double fuelAmount)
        {
            if (fuelAmount + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }
            base.Refuel(fuelAmount* truckerFactor);
        }
    }
}
