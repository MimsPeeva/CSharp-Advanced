using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class RobotRepository:IRepository<IRobot>
    {
        private readonly List<IRobot> robotsRep;

        public RobotRepository()
        {
            robotsRep = new List<IRobot>();
        }

        public IReadOnlyCollection<IRobot> Models() => robotsRep.AsReadOnly();
        
        public void AddNew(IRobot model)
        {
           robotsRep.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
          return robotsRep.Remove(robotsRep.FirstOrDefault(r => r.GetType().Name == typeName));
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return robotsRep.FirstOrDefault(r => r.InterfaceStandards.Any(s=>s== interfaceStandard) );
        }
    }
}
