using RobotService.Models.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models;

public abstract class Robot : IRobot
{
    private string model;
    private int batteryCapacity;

    private readonly List<int> interfaceStandards;

    public Robot(string model, int batteryCapacity, int convertionCapacityIndex)
    {
        Model = model;
        BatteryCapacity = batteryCapacity;
        BatteryLevel = batteryCapacity;
        ConvertionCapacityIndex = convertionCapacityIndex;

        interfaceStandards = new List<int>();
    }

    public string Model
    {
        get => model;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.ModelNullOrWhitespace);
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
                throw new ArgumentException(ExceptionMessages.BatteryCapacityBelowZero);
            }

            batteryCapacity = value;
        }
    }

    public int BatteryLevel { get; private set; }

    public int ConvertionCapacityIndex { get; private set; }

    public IReadOnlyCollection<int> InterfaceStandards => interfaceStandards.AsReadOnly();

    public void Eating(int minutes)
    {
        int totalCapacity = ConvertionCapacityIndex * minutes;

        if (totalCapacity > BatteryCapacity - BatteryLevel)
        {
            BatteryLevel = batteryCapacity;
        }
        else
        {
            BatteryLevel += totalCapacity;
        }
    }

    public void InstallSupplement(ISupplement supplement)
    {
        interfaceStandards.Add(supplement.InterfaceStandard);
        BatteryCapacity -= supplement.BatteryUsage;
        BatteryLevel -= supplement.BatteryUsage;
    }

    public bool ExecuteService(int consumedEnergy)
    {
        if (BatteryLevel >= consumedEnergy)
        {
            BatteryLevel -= consumedEnergy;

            return true;
        }

        return false;
    }

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.AppendLine($"{GetType().Name} {Model}:");
        sb.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
        sb.AppendLine($"--Current battery level: {BatteryLevel}");

        string supplementsInstalled = InterfaceStandards.Any()
            ? $"{string.Join(" ", InterfaceStandards)}"
            : "none";

        sb.AppendLine($"--Supplements installed: {supplementsInstalled}");

        return sb.ToString().TrimEnd();
    }
}
