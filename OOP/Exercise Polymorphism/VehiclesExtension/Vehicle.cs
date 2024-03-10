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
        private double tankCapacity;
        protected Vehicle(double tankCapacity, double fuelConsumptionInLPerKm, double fuelQuantity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumptionInLPerKm = fuelConsumptionInLPerKm;
            TankCapacity = tankCapacity;
        }
        public double TankCapacity
        {
            get { return tankCapacity; }
            protected set 
            {
                if (value <= 0)
                { throw new ArgumentException("Tank capacity must be positive number"); }
                tankCapacity = value;
                if (value < TankCapacity)
                {
                    fuelQuantity = value;
                }
                else { fuelQuantity = 0; }
            }
        }
        public double FuelQuantity 
        {
            get
            { return fuelQuantity; }
          protected  set
            {
                if (value < 0)
                { throw new ArgumentException("Fuel must be possitive number!"); }
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else { fuelQuantity = value; }
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
            if (fuelAmount <= 0)
            { throw new ArgumentException("Fuel must be a positive number"); }
            double totalFuelAfterRefueling = fuelAmount * fuelQuantity;
            if (totalFuelAfterRefueling > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {fuelAmount} fuel in the tank");
            }
            FuelQuantity+=fuelAmount;
        }
        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}".ToString();
        }
    }
    }
