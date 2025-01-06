namespace RobotService.Core.Contracts;

public interface IController
{
    string CreateRobot(string model, string typeName);
    string CreateSupplement(string typeName);
    string UpgradeRobot(string model, string supplementTypeName);
    string RobotRecovery(string model, int minutes);
    string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded);
    string Report();
}
