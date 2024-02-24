using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class RaceMotorcycle:Motorcycle
    {
        public RaceMotorcycle(int horsePower,double fuel ) : base(horsePower, fuel)
        {
            DefaultFuelConsumption = 8;
        }
        public new double DefaultFuelConsumption { get; set; }
        public override void Drive(double kilometers)
        {
            Fuel -= kilometers * DefaultFuelConsumption;
        }

    }
}
