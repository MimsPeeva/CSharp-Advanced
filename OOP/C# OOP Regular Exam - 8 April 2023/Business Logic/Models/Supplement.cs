using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;

namespace RobotService.Models
{
    public class Supplement:ISupplement
    {
        public Supplement(int interfaceStandard, int batteryUsage)
        {
            InterfaceStandard = interfaceStandard;
            BatteryUsage = batteryUsage;
        }

        private int interfaceStandard;
        private int batteryUsage;

        public int InterfaceStandard
        {
            get => interfaceStandard;
            private set { interfaceStandard = value; }
        }
        public int BatteryUsage
        {
            get => batteryUsage;
            private set { batteryUsage = value; }
        }
    }
}
