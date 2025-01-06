namespace RobotService.Models;

public class IndustrialAssistant : Robot
{
    private const int IndustrialAssistantBatteryCapacity = 40_000;
    private const int IndustrialAssistantConvertionCapacityIndex = 5_000;

    public IndustrialAssistant(string model)
        : base(model, IndustrialAssistantBatteryCapacity, IndustrialAssistantConvertionCapacityIndex)
    {
    }
}
