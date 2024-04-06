using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Core
{
    public class Controller:IController
    {
        public Controller()
        {
            this.playersRep = new PlayerRepository();
            this.teamsRep = new TeamRepository();
        }

        private IRepository<IPlayer> playersRep;
        private IRepository<ITeam> teamsRep;


        public string NewTeam(string name)
        {
            if (teamsRep.ExistsModel(name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
            }

            teamsRep.AddModel(new Team(name));
            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));


        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName is not ("Goalkeeper" or "CenterBack" or "ForwardWing"))
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            if (playersRep.ExistsModel(name))
            {
                IPlayer pl = playersRep.GetModel(name);
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, typeof(PlayerRepository).Name,
                    pl.GetType().Name);
            }

            IPlayer player = null;
            if (typeName == typeof(Goalkeeper).Name)
            {
                player = new Goalkeeper(name);
            }
            if (typeName == typeof(CenterBack).Name)
            {
                player = new CenterBack(name);
            }
            if (typeName == typeof(ForwardWing).Name)
            {
                player = new ForwardWing(name);
            }
            playersRep.AddModel(player);
            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }



        public string NewContract(string playerName, string teamName)
        {
            if (!playersRep.ExistsModel(playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }
            if (!teamsRep.ExistsModel(teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
            }

            IPlayer player = playersRep.GetModel(playerName);
            ITeam team = teamsRep.GetModel(teamName);

            if (player.Team != default)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }


            player.JoinTeam(teamName);
            team.SignContract(player);
            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam firstTeam = teamsRep.GetModel(firstTeamName);
            ITeam secondTeam = teamsRep.GetModel(secondTeamName);
            if (firstTeam.OverallRating != secondTeam.OverallRating)
            {
                ITeam winner;
                ITeam loser;
                if (firstTeam.OverallRating > secondTeam.OverallRating)
                {
                    winner = firstTeam;
                    loser = secondTeam;
                }
                else
                {
                    winner = secondTeam;
                    loser = firstTeam;
                }
                winner.Win();
                loser.Lose();
                return string.Format(OutputMessages.GameHasWinner, winner.Name, loser.Name);
            }

            else
            {
                firstTeam.Draw();
                secondTeam.Draw();
                return string.Format(OutputMessages.GameIsDraw, firstTeam.Name, secondTeam.Name);
            }
        }





        public string PlayerStatistics(string teamName)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"***{teamName}***");
            ITeam team = teamsRep.GetModel(teamName);
            var players = team.Players.OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name).ToList();
            foreach (var player in players)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().Trim();
        }

        public string LeagueStandings()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***League Standings***");
            List<ITeam> teams = teamsRep.Models.OrderByDescending(p => p.PointsEarned)
                .ThenByDescending(p => p.OverallRating)
                .ThenBy(p => p.Name)
                .ToList();
            foreach (var team in teams)
            {
                sb.AppendLine(team.ToString());
            }

            return sb.ToString().Trim();
        }



    }
}
