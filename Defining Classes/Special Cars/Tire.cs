using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tires
    {
        private int year;
        private double pressure;

        public Tires(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        public int Year 
        { 
            get { return this.year; }
            set { this.year = value; }
        }
        public double Pressure
        {
            get { return this.pressure; }
            set { this.pressure = value; }
        }
    }
}
