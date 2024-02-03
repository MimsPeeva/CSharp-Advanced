

using System.Text;

namespace CarManufacturer

{

    public class Car

    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;
        private Engine engine;
        private Tires[] tires;
        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption) : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption,Engine engine, Tires[] tires) :
            this(make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tire = tires;
        }
        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set { this.year = value; }
        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set { this.fuelQuantity = value; }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set { this.fuelConsumption = value; }
        }
        public Engine Engine
        {
            get { return this.engine; }
            set { this.engine = value; }
        }
        public Tires[] Tire
        {
            get { return this.tires; }
            set { this.tires = value; }
        }
        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption / 100) > 0)
            {
                FuelQuantity -= (distance * FuelConsumption / 100);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder str = new();
            str.AppendLine($"Make: {this.Make}");
            str.AppendLine($"Model: {this.Model}");
            str.AppendLine($"Year: {this.Year}");
            str.AppendLine($"HorsePowers: {this.Engine.HorsePower}");
            str.AppendLine($"FuelQuantity: {this.FuelQuantity}");
            return str.ToString().TrimEnd();
        }
    }
   
    }

