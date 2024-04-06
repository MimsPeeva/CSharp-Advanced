using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handball.Models.Contracts;
using Handball.Repositories.Contracts;

namespace Handball.Repositories
{
    public class PlayerRepository:IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => players;
        public void AddModel(IPlayer model)
        {
          players.Add(model);
        }

        public bool RemoveModel(string name)
        {
            IPlayer currPlayer = players.FirstOrDefault(x => x.Name == name);
            return players.Remove(currPlayer);
        }

        public bool ExistsModel(string name)
        {
            IPlayer currPlayer = players.FirstOrDefault(x => x.Name == name);
            return players.Contains(currPlayer);
        }

        public IPlayer GetModel(string name)
        {
            IPlayer currPlayer = players.FirstOrDefault(x => x.Name == name);
            if (currPlayer!=null)
            {
                
            return currPlayer;
            }

            return null;
        }
    }
}
