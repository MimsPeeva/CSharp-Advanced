﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models
{
    public class Robot:IRobot
    {
        public Robot(string model, int batteryCapacity, int convertionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
           this.batteryLevel = batteryCapacity;
            this.convertionCapacityIndex = convertionCapacityIndex;
            interfaceStandards = new List<int>();
        }

        private string model;
        private int batteryCapacity;
       private int batteryLevel;
        private int convertionCapacityIndex;
        private List<int> interfaceStandards;
        public string Model
        {
            get=>model;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                { 
                  throw  new ArgumentException(string.Format(ExceptionMessages.ModelNullOrWhitespace));
                }
                model = value;
            }
        }

        public int BatteryCapacity
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.BatteryCapacityBelowZero));
                }

                batteryCapacity = value;

            }
        }


        public int BatteryLevel => this.batteryLevel;

        public int ConvertionCapacityIndex => convertionCapacityIndex;
        public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards;
        public void Eating(int minutes)
        {
            int produceEnergy = ConvertionCapacityIndex * minutes;
            if (produceEnergy > BatteryCapacity - BatteryLevel)
            {
                batteryLevel = batteryCapacity;
            }
            else
            {
                batteryLevel += produceEnergy;
            }
        }

        public void InstallSupplement(ISupplement supplement)
        {
            BatteryCapacity -= supplement.BatteryUsage;
            batteryLevel-=supplement.BatteryUsage;
            interfaceStandards.Add(supplement.InterfaceStandard);
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (batteryLevel >= consumedEnergy)
            {
                batteryLevel -= consumedEnergy;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} {Model}");
            sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            sb.AppendLine($"--Current battery level: {BatteryLevel}");
            if (interfaceStandards.Count == 0)
            {
                sb.AppendLine($"--Supplements installed: none");
            }
            else sb.AppendLine($"--Supplements installed: {string.Join(" ", interfaceStandards)}");
            return sb.ToString().Trim();
        }

    }
}
