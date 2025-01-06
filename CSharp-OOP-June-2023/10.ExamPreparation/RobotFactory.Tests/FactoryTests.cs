using NUnit.Framework;
using System.Linq;

namespace RobotFactory.Tests;

[TestFixture]
public class FactoryTests
{
    private Factory factory;

    [SetUp]
    public void Setup()
    {
        factory = new("Ivan", 10);
    }

    [Test]
    public void ConstructorShouldWorkCorrectly()
    {
        string expectedName = "Ivan";
        int expectedCapacity = 10;

        Assert.AreEqual(expectedName, factory.Name);
        Assert.AreEqual(expectedCapacity, factory.Capacity);
        Assert.NotNull(factory.Robots);
        Assert.NotNull(factory.Supplements);
    }

    [Test]
    public void NameSetterShouldWorkCorrectly()
    {
        string expectedName = "Peter";

        factory.Name = expectedName;

        Assert.AreEqual(expectedName, factory.Name);
    }

    [Test]
    public void CapacitySetterShouldWorkCorrectly()
    {
        int expectedCapacity = 20;

        factory.Capacity = expectedCapacity;

        Assert.AreEqual(expectedCapacity, factory.Capacity);
    }

    [Test]
    public void ProduceRobotShouldAddRobotToInnerCollection()
    {
        Robot expectedRobot = new("Terminator", 1000.2341, 24);

        string expectedMessage = $"Produced --> Robot model: {expectedRobot.Model} IS: {expectedRobot.InterfaceStandard}, Price: {expectedRobot.Price:f2}";

        string actualMessage = factory.ProduceRobot("Terminator", 1000.2341, 24);

        Robot actualRobot = factory.Robots.Single();

        Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
        Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
        Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void ProduceRobotShouldNotAddRobotToInnerCollectionWhenCapacityLimitIsReached()
    {
        string expectedMessage = $"The factory is unable to produce more robots for this production day!";

        factory.Capacity = 0;

        string actualMessage = factory.ProduceRobot("Terminator", 1000.2341, 24);

        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void ProduceSupplemenShouldAddSuplementToInnerCollection()
    {
        Supplement expectedSupplement = new("Laser", 25);

        string expectedMessage = $"Supplement: {expectedSupplement.Name} IS: {expectedSupplement.InterfaceStandard}";

        string actualMessage = factory.ProduceSupplement(expectedSupplement.Name, expectedSupplement.InterfaceStandard);

        Supplement actualSupplement = factory.Supplements.Single();

        Assert.AreEqual(expectedSupplement.Name, actualSupplement.Name);
        Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSupplement.InterfaceStandard);
        Assert.AreEqual(expectedMessage, actualMessage);
    }

    [Test]
    public void UpgradeRobotShouldAddSupplementAndReturnTrue()
    {
        Robot robot = new("Terminator", 1000.2341, 25);

        Supplement expectedSupplement = new("Laser", 25);

        bool actualResult = factory.UpgradeRobot(robot, expectedSupplement);

        Supplement actualSuplement = robot.Supplements.Single();

        Assert.True(actualResult);
        Assert.AreEqual(expectedSupplement.Name, actualSuplement.Name);
        Assert.AreEqual(expectedSupplement.InterfaceStandard, actualSuplement.InterfaceStandard);
    }

    [TestCase]
    public void UpgradeRobotShouldNotAddSupplementAndReturnFalseWhenSupplementAlreadyAdded()
    {
        Robot robot = new("Terminator", 1000.2341, 25);

        Supplement expectedSupplement = new("Laser", 25);

        _ = factory.UpgradeRobot(robot, expectedSupplement);
        bool expectedResult = factory.UpgradeRobot(robot, expectedSupplement);

        Assert.False(expectedResult);
        Assert.AreEqual(1, robot.Supplements.Count);
    }

    [TestCase]
    public void UpgradeRobotShouldNotAddSupplementAndReturnFalseWhenInterfaceStandardsDoesNotMatch()
    {
        int interfaceStandard = 24;

        Robot robot = new("Terminator", 1000.2341, interfaceStandard);

        Supplement expectedSupplement = new("Laser", interfaceStandard + 1);

        bool expectedResult = factory.UpgradeRobot(robot, expectedSupplement);

        Assert.False(expectedResult);
    }

    [TestCase]
    public void SellRobotShouldReturnCorrectRobot()
    {
        Robot expectedRobot = new("Terminator", 700, 24);

        _ = factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
        _ = factory.ProduceRobot("Terminator2", 1000, 25);
        _ = factory.ProduceRobot("Terminator3", 500, 26);


        Robot actualRobot = factory.SellRobot(800);

        Assert.AreEqual(expectedRobot.Model, actualRobot.Model);
        Assert.AreEqual(expectedRobot.InterfaceStandard, actualRobot.InterfaceStandard);
        Assert.AreEqual(expectedRobot.Price, actualRobot.Price);
    }

    [Test]
    public void SellRobotShouldReturnNullIfPriceIsTooLow()
    {
        Robot expectedRobot = new("Terminator", 700, 24);

        _ = factory.ProduceRobot(expectedRobot.Model, expectedRobot.Price, expectedRobot.InterfaceStandard);
        _ = factory.ProduceRobot("Terminator2", 1000, 25);
        _ = factory.ProduceRobot("Terminator3", 500, 26);

        Robot actualRobot = factory.SellRobot(20);

        Assert.Null(actualRobot);
    }

    [Test]
    public void SellRobotShouldReturnNullIfRobotsCollectionIsEmpty()
    {
        Robot actualRobot = factory.SellRobot(20);

        Assert.Null(actualRobot);
    }
}