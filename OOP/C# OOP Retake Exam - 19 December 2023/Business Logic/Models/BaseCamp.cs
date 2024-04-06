using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp:IBaseCamp
    {
        private SortedSet<string> resdents;

        public BaseCamp()
        {
            resdents = new SortedSet<string>();
        }

        public IReadOnlyCollection<string> Residents => resdents;
        
        public void ArriveAtCamp(string climberName)
        {
            resdents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            resdents.Remove(climberName);
        }
    }
}
