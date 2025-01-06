namespace RobotService.Utilities.Messages;

public class OutputMessages
{
    public const string RobotCannotBeCreated = "Robot type {0} cannot be created.";
    public const string RobotCreatedSuccessfully = "{0} {1} is created and added to the RobotRepository.";

    public const string SupplementCannotBeCreated = "{0} is not compatible with our robots.";
    public const string SupplementCreatedSuccessfully = "{0} is created and added to the SupplementRepository.";

    public const string AllModelsUpgraded = "All {0} are already upgraded!";
    public const string UpgradeSuccessful = "{0} is upgraded with {1}.";

    public const string RobotsFed = "Robots fed: {0}";

    public const string UnableToPerform = "Unable to perform service, {0} not supported!";
    public const string MorePowerNeeded = "{0} cannot be executed! {1} more power needed.";
    public const string PerformedSuccessfully = "{0} is performed successfully with {1} robots.";
}
