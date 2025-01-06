namespace RobotService.Models.Contracts;

using System.Collections.Generic;
public interface IRobot
{
    public string Model { get; }

    public int BatteryCapacity { get; }

    public int BatteryLevel { get; }

    public int ConvertionCapacityIndex { get; }

    public IReadOnlyCollection<int> InterfaceStandards { get; }

    void Eating(int minutes);

    void InstallSupplement(ISupplement supplement);

    bool ExecuteService(int consumedEnergy);
}
