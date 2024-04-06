using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private DiverRepository divers;
        private FishRepository fishes;

        private string[] diverTypes = new[]
        {
            typeof(ScubaDiver).Name,
            typeof(FreeDiver).Name
        };

        private string[] fishTypes = new[]
        {
            typeof(ReefFish).Name,
            typeof(DeepSeaFish).Name,
            typeof(PredatoryFish).Name
        };

        public Controller()
        {
            divers = new DiverRepository();
            fishes = new FishRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (!diverTypes.Contains(diverType))
            {
                return String.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return String.Format(OutputMessages.DiverNameDuplication, diverName, typeof(DiverRepository).Name);
            }

            IDiver diver = null;
            if (diverType == typeof(ScubaDiver).Name)
            {
                diver = new ScubaDiver(diverName);
            }

            if (diverType == typeof(FreeDiver).Name)
            {
                diver = new FreeDiver(diverName);
            }
            divers.AddModel(diver);
            return String.Format(OutputMessages.DiverRegistered, diverName, typeof(DiverRepository).Name);

        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (!fishTypes.Contains(fishType))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fishes.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, typeof(FishRepository).Name);
            }

            IFish fish = null;
            if (fishType == typeof(ReefFish).Name)
            {
                fish = new ReefFish(fishName, points);
            }

            if (fishType == typeof(DeepSeaFish).Name)
            {
                fish = new DeepSeaFish(fishName, points);
            }

            if (fishType == typeof(PredatoryFish).Name)
            {
                fish = new PredatoryFish(fishName, points);
            }
            fishes.AddModel(fish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            if (divers.GetModel(diverName) ==null)
            {
                return string.Format(OutputMessages.DiverNotFound, typeof(DiverRepository).Name, diverName);
            }
            if (fishes.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            IDiver diver = divers.GetModel(diverName);
            IFish fish = fishes.GetModel(fishName);
            if (diver.HasHealthIssues)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }
            else if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky)
                {
                    diver.Hit(fish);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fish.Name);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);
                    return string.Format(OutputMessages.DiverMisses, diverName, fish.Name);
                }
            }

           else
            {
                diver.Hit(fish);
                return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fish.Name);

            }

        }

        public string HealthRecovery()
        {
            List<IDiver> healthIssueDivers = divers.Models.Where(x => x.HasHealthIssues == true).ToList();
            foreach (var diver in healthIssueDivers)
            {
                diver.UpdateHealthStatus();
                diver.RenewOxy();
            }
            return string.Format(OutputMessages.DiversRecovered, healthIssueDivers.Count);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");
            foreach (var coughtFish in diver.Catch)
            {
                sb.AppendLine(fishes.GetModel(coughtFish).ToString());
            }
            return sb.ToString().Trim();
        }

        public string CompetitionStatistics()
        {
            List<IDiver> goodHealthDivers = divers.Models.Where(x => x.HasHealthIssues == false).
                OrderByDescending(x=>x.CompetitionPoints)
                .ThenByDescending(x=>x.Catch.Count)
                .ThenBy(x=>x.Name)
                .ToList();
            StringBuilder sb= new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (var diver in goodHealthDivers)
            {
                sb.AppendLine(diver.ToString()); 
            }

            return sb.ToString().Trim();
        }
    }
}
