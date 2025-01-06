using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core;

public class Controller : IController
{
    IRepository<ISupplement> supplements;
    IRepository<IRobot> robots;

    public Controller()
    {
        supplements = new SupplementRepository();
        robots = new RobotRepository();
    }

    public string CreateRobot(string model, string typeName)
    {
        IRobot robot;

        if (typeName == nameof(DomesticAssistant))
        {
            robot = new DomesticAssistant(model);
        }
        else if (typeName == nameof(IndustrialAssistant))
        {
            robot = new IndustrialAssistant(model);
        }
        else
        {
            return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
        }

        robots.AddNew(robot);

        return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
    }

    public string CreateSupplement(string typeName)
    {
        ISupplement supplement;

        if (typeName == nameof(SpecializedArm))
        {
            supplement = new SpecializedArm();
        }
        else if (typeName == nameof(LaserRadar))
        {
            supplement = new LaserRadar();
        }
        else
        {
            return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
        }

        supplements.AddNew(supplement);

        return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
    }

    public string UpgradeRobot(string model, string supplementTypeName)
    {
        ISupplement supplement = supplements
            .Models()
            .FirstOrDefault(s => s.GetType().Name == supplementTypeName);

        IRobot robot = robots
            .Models()
            .FirstOrDefault(r => r.Model == model && !r.InterfaceStandards.Contains(supplement.InterfaceStandard));

        if (robot is null)
        {
            return string.Format(OutputMessages.AllModelsUpgraded, model);
        }

        robot.InstallSupplement(supplement);
        supplements.RemoveByName(supplementTypeName);

        return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
    }

    public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
    {
        IEnumerable<IRobot> filteredRobots = robots
            .Models()
            .Where(r => r.InterfaceStandards.Contains(intefaceStandard))
            .OrderByDescending(r => r.BatteryLevel);

        if (!filteredRobots.Any())
        {
            return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
        }

        int availablePower = filteredRobots.Sum(r => r.BatteryLevel);

        if (availablePower < totalPowerNeeded)
        {
            return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - availablePower);
        }

        int robotsCounter = 0;

        foreach (IRobot robot in filteredRobots)
        {
            robotsCounter++;

            if (robot.BatteryLevel >= totalPowerNeeded)
            {
                robot.ExecuteService(totalPowerNeeded);

                break;
            }

            totalPowerNeeded -= robot.BatteryLevel;
            robot.ExecuteService(robot.BatteryLevel);
        }

        return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotsCounter);
    }

    //public string RobotRecovery(string model, int minutes)
    //{
    //    IEnumerable<IRobot> filteredRobots = robots
    //        .Models()
    //        .Where(r => r.Model == model && r.BatteryCapacity / 2 > r.BatteryLevel);

    //    int robotsCount = 0;

    //    foreach (IRobot robot in filteredRobots)
    //    {
    //        robotsCount++;
    //        robot.Eating(minutes);
    //    }

    //    return string.Format(OutputMessages.RobotsFed, robotsCount);
    //}


    public string RobotRecovery(string model, int minutes)
    {
        IEnumerable<IRobot> filteredRobots = robots
            .Models()
            .Where(r => r.Model == model && r.BatteryCapacity / 2 > r.BatteryLevel);

        int robotsCount = 0;

        foreach (IRobot robot in filteredRobots)
        {
            robotsCount++;
            robot.Eating(minutes);
        }

        return string.Format(OutputMessages.RobotsFed, robotsCount);
    }

    public string Report()
    {
        IEnumerable<IRobot> orderedRobots = robots
            .Models()
            .OrderByDescending(r => r.BatteryLevel)
            .ThenBy(b => b.BatteryCapacity);

        StringBuilder sb = new StringBuilder();

        foreach (IRobot robot in orderedRobots)
        {
            sb.AppendLine(robot.ToString());
        }

        return sb.ToString().TrimEnd();
    }
}
