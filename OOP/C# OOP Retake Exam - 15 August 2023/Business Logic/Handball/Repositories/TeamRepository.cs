using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class TeamRepository:IRepository<ITeam>
    {
        private List<ITeam> teams;

        public TeamRepository()
        {
            teams = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => teams;
        public void AddModel(ITeam model)
        {
          teams.Add(model);
        }

        public bool RemoveModel(string name)
        {
            ITeam currTeam = teams.FirstOrDefault(x => x.Name == name);
            return teams.Remove(currTeam);
        }

        public bool ExistsModel(string name)
        {
            ITeam currTeam = teams.FirstOrDefault(x => x.Name == name);
            return teams.Contains(currTeam);
        }

        public ITeam GetModel(string name)
        {
            ITeam currTeam = teams.FirstOrDefault(x => x.Name == name);
            if (currTeam != null)
            {

                return currTeam;
            }

            return null;
        }
    }
}
