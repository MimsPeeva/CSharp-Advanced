﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Speed_Racing
{
    public class Car
    {
        private string model;

        private double fuelAmount;

        private double fuelConsumptionPerKilometer;

        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
            {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
            }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value;}
        }
        public double TravelledDistance
        {
            get {return travelledDistance; }
            set { travelledDistance = value; }
        }
        public void Moving(double distance)
        {
            if (fuelConsumptionPerKilometer * distance > fuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                fuelAmount -= distance * fuelConsumptionPerKilometer;
                travelledDistance += distance;
            }
        }
    }
}
