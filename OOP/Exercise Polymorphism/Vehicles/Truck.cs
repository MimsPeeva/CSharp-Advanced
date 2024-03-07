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
        public Truck(double fuelQuantity, double fuelConsumptionInLPerKm) :
             base(fuelQuantity, fuelConsumptionInLPerKm+increasedConsumation)
        {
        }
      public override void Refuel(double fuelAmount)
        { 
            base.Refuel(fuelAmount* truckerFactor);
        }
    }
}
