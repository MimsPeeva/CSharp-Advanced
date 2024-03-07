using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Car : Vehicle
    {
        private const double increasedConsumation = 0.9;
     
        public Car(double fuelQuantity, double fuelConsumptionInLPerKm, double tankCapacity) :
            base(fuelQuantity, fuelConsumptionInLPerKm+increasedConsumation,tankCapacity)
        {
        }
        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount);
        }
    }
}
