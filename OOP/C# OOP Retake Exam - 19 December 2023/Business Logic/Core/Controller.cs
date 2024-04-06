using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using HighwayToPeak.Core.Contracts;
using HighwayToPeak.Models;
using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories;
using HighwayToPeak.Repositories.Contracts;
using HighwayToPeak.Utilities.Messages;

namespace HighwayToPeak.Core
{
    public class Controller:IController
    {
        private IRepository<IPeak> peaks;
        private IRepository<IClimber> climbers;
        private BaseCamp baseCamp;
        public Controller()
        {
            this.peaks = new PeakRepository();
            this.climbers = new ClimberRepository();
            this.baseCamp = new BaseCamp();
        }


        public string AddPeak(string name, int elevation, string difficultyLevel)
        {
            IPeak currPeak;
            //if ((currPeak = peaks.Get(name)) is not null)
            if (peaks.Get(name)is not null)
            {
                return string.Format(OutputMessages.PeakAlreadyAdded, name);
            }

            if (difficultyLevel is not ("Extreme" or "Hard" or "Moderate"))
            {
                return string.Format(OutputMessages.PeakDiffucultyLevelInvalid,difficultyLevel);
            }

            IPeak newPeak = new Peak(name, elevation, difficultyLevel);
            peaks.Add(newPeak);
            return string.Format(OutputMessages.PeakIsAllowed, name,peaks.GetType().Name);
        }

        public string NewClimberAtCamp(string name, bool isOxygenUsed)
        {
            IClimber currClimber;
            if (climbers.Get(name) is not null)
            {
                return string.Format(OutputMessages.ClimberCannotBeDuplicated, name,climbers.GetType().Name);
            }

            if (isOxygenUsed)
            {
                 currClimber = new OxygenClimber(name);
            }
            else
            {
                currClimber = new NaturalClimber(name);
            }
            climbers.Add(currClimber);
            baseCamp.ArriveAtCamp(name);
            return string.Format(OutputMessages.ClimberArrivedAtBaseCamp, name);
        }

        public string AttackPeak(string climberName, string peakName)
        {
            IClimber currClimber;
            IPeak currPeak;
            if ((currClimber = climbers.Get(climberName)) == null)
            {
                return string.Format(OutputMessages.ClimberNotArrivedYet, climberName);
            }

            if ((currPeak = peaks.Get(peakName)) == null)
            {
                return string.Format(OutputMessages.PeakIsNotAllowed, peakName);
            }
            if (baseCamp.Residents.Contains(climberName) == false)
            {
                return string.Format(OutputMessages.ClimberNotFoundForInstructions, climberName, peakName);
            }


            if (currClimber.GetType().Name == "NaturalClimber" &&
                currPeak.DifficultyLevel == "Extreme")
            {
                return string.Format(OutputMessages.NotCorrespondingDifficultyLevel, climberName, peakName);
            }
            baseCamp.LeaveCamp(climberName);
            currClimber.Climb(currPeak);
            if (currClimber.Stamina == 0)
            {
                return string.Format(OutputMessages.NotSuccessfullAttack, climberName);
            }
            baseCamp.ArriveAtCamp(currClimber.Name);
            return string.Format(OutputMessages.SuccessfulAttack, currClimber.Name, currPeak.Name);


        }

        public string CampRecovery(string climberName, int daysToRecover)
            {
                IClimber currClimber = climbers.Get(climberName);
                if (!baseCamp.Residents.Contains(climberName))
                {
                    return string.Format(OutputMessages.ClimberIsNotAtBaseCamp, climberName);
                }

                if (currClimber.Stamina == 10)
                {
                    return string.Format(OutputMessages.NoNeedOfRecovery, currClimber.Name);
                }
                currClimber.Rest(daysToRecover);
                return string.Format(OutputMessages.ClimberRecovered, currClimber.Name, daysToRecover);
            }

        public string BaseCampReport()
        {
            if (baseCamp.Residents.Count==0)
            {
                return "BaseCamp is currently empty.";
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BaseCamp residents:");
            foreach (var resident in baseCamp.Residents)
            {
                var currResident = climbers.All.FirstOrDefault(x => x.Name == resident);
                sb.AppendLine($"Name: {currResident.Name}, Stamina: {currResident.Stamina}, Count of Conquered Peaks: {currResident.ConqueredPeaks.Count}");
            }
                return sb.ToString().Trim();
        }

        public string OverallStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***Highway-To-Peak***");
            var sortedClimbers =
                climbers.All.OrderByDescending(x => x.ConqueredPeaks.Count).ThenBy(x => x.Name);
            foreach (var climber in sortedClimbers)
            {
                sb.AppendLine(climber.ToString());
                List<IPeak> sortedPeaks = climber.ConqueredPeaks
                    .Select(peakName => peaks.Get(peakName))
                    .OrderByDescending(peak => peak.Elevation)
                    .ToList();
                foreach (var peak in sortedPeaks)
                {
                    sb.AppendLine(peak.ToString());
                }
            }
            return sb.ToString().Trim();
        }
    }
}
