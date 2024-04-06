using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;

namespace RobotService.Repositories
{
    public class SupplementRepository:IRepository<ISupplement>
    {
        private readonly List<ISupplement> supplimentsRep;

        public SupplementRepository()
        {
            supplimentsRep = new List<ISupplement>();
        }

        public IReadOnlyCollection<ISupplement> Models() => supplimentsRep.AsReadOnly();
        

        public void AddNew(ISupplement model)
        {
           supplimentsRep.Add(model);
        }

        public bool RemoveByName(string typeName)
        {
            return supplimentsRep.Remove(supplimentsRep.FirstOrDefault(s=>s.GetType().Name==typeName));
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return supplimentsRep.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
        }
    }
}
