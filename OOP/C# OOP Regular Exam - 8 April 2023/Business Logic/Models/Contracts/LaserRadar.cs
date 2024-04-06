using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models.Contracts
{
    public class LaserRadar:Supplement
    {
        private const int interfaseSt = 20082;
        private const int batteryUssageConst = 5000;
        public LaserRadar() : base(interfaseSt, batteryUssageConst)
        {
        }
    }
}
