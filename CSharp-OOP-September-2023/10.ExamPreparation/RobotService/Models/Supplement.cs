using RobotService.Models.Contracts;

namespace RobotService.Models;

public abstract class Supplement : ISupplement
{
    public Supplement(int interfaceStandard, int batteryUsage)
    {
        InterfaceStandard = interfaceStandard;
        BatteryUsage = batteryUsage;
    }

    public int InterfaceStandard { get; private set; }

    public int BatteryUsage { get; private set; }
}
