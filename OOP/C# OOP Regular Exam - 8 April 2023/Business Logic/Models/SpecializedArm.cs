using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class SpecializedArm:Supplement
    {
        private const int interfaseSt = 10045;
        private const int batteryUssageConst = 10000;
        public SpecializedArm() : base(interfaseSt, batteryUssageConst)
        {
        }
    }
}
