using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Salesman
{
    public class Engine
    {
        private string model;
        private int power;
        private int displacement;
        private string efficiency;
        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
        }
        public Engine(string model, int power, int displacement, string efficiency):this(model, power)
        {
          
            this.displacement = displacement;
            this.efficiency = efficiency;
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public int Displacement
        {
            get { return displacement; }
            set { displacement = value; }
        }
        public string Efficiency
        {
            get { return efficiency; }
            set { efficiency = value; }
        }
        public override string ToString()
        {
            string displacement = Displacement == 0 ? "n/a" : Displacement.ToString();
            string efficiency = Efficiency ?? "n/a";

            StringBuilder stringBuilder = new();

            stringBuilder.AppendLine($"{Model}:");
            stringBuilder.AppendLine($"    Power: {Power}");
            stringBuilder.AppendLine($"    Displacement: {displacement}");
            stringBuilder.AppendLine($"    Efficiency: {efficiency}");

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
