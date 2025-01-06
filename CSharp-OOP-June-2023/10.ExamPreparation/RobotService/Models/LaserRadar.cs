namespace RobotService.Models;

public class LaserRadar : Supplement
{
    private const int LaserRadarInterfaceStandard = 20_082;
    private const int LaserRadarArmBatteryUsage = 5_000;

    public LaserRadar()
        : base(LaserRadarInterfaceStandard, LaserRadarArmBatteryUsage)
    {
    }
}
