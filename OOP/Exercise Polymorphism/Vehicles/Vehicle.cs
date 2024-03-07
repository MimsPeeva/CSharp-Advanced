using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle:IDrivable,IRefuelable
    {
        private double fuelQuantity;
        private double fuelConsumptionInLPerKm;

        protected Vehicle(double fuelQuantity, double fuelConsumptionInLPerKm)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionInLPerKm = fuelConsumptionInLPerKm;
        }

        public double FuelQuantity 
        {
            get
            { return fuelQuantity; }
          protected  set
            {
                if (value < 0)
                { throw new ArgumentException("Fuel must be possitive number!"); }
                fuelQuantity = value;
            }
        } 
        public double FuelConsumptionInLPerKm
        {
            get
            { return fuelConsumptionInLPerKm; }
            protected set
            {
                if (value < 0)
                { throw new ArgumentException("Consumation must be possitive number!"); }
                fuelConsumptionInLPerKm = value;
            }
        }
        

       public virtual void Drive(double distance)
        {
            double totalConsumption = distance * fuelConsumptionInLPerKm;
            if (totalConsumption>FuelQuantity)
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
            FuelQuantity -= totalConsumption;
            Console.WriteLine($"{GetType().Name} travelled {distance} km");
        }

        public virtual void Refuel(double fuelAmount)
        {
            if(fuelAmount<=0)
            throw new ArgumentException("FuelAmount must be positive number!");
            FuelQuantity+=fuelAmount;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}".ToString();
        }
    }
    }
