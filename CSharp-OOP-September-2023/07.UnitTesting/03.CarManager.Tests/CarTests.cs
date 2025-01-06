namespace Tests;

using CarManager;
using NUnit.Framework;
using System;

[TestFixture]
public class CarTests
{
    private Car car;

    [SetUp]
    public void SetUp()
    {
        car = new Car("Mercedes", "S63", 7.5, 50.0);
    }

    [Test]
    public void CarShouldBeCreatedSuccessfully()
    {
        string expectedMake = "Mercedes";
        string expectedModel = "S63";
        double expectedFuelConsumption = 7.5;
        double expectedFuelCapacity = 50.0;

        Assert.AreEqual(expectedMake, car.Make);
        Assert.AreEqual(expectedModel, car.Model);
        Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
        Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
    }

    [Test]
    public void CarShouldBeCreatedWithZeroFuelAmount()
    {
        Assert.AreEqual(0, car.FuelAmount);
    }

    [TestCase(null)]
    [TestCase("")]
    public void CarMakeShouldThrowExceptionIfIsSetToNull(string make)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => new Car(make, "S63", 7.5, 50.0));

        Assert.AreEqual("Make cannot be null or empty!", exception.Message);
    }

    [TestCase(null)]
    [TestCase("")]
    public void CarModelShouldThrowExceptionIfIsSetToNull(string model)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => new Car("Mercedes", model, 7.5, 50.0));

        Assert.AreEqual("Model cannot be null or empty!", exception.Message);
    }

    [TestCase(0)]
    [TestCase(-3)]
    public void CarFuelConsumptionShouldThrowExceptionIfIsNegativeOrZero(int fuelConsumption)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => new Car("Mercedes", "S63", fuelConsumption, 50.0));

        Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
    }

    [Test]
    public void CarFuelAmountShouldThrowExceptionIfIsNegative()
    {
        Assert.Throws<InvalidOperationException>(()
            => car.Drive(12), "Fuel amount cannot be negative!");
    }

    [TestCase(0)]
    [TestCase(-2)]
    public void CarFuelCapacityShouldThrowExceptionIfIsNegativeOrZero(int fuelCapacity)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => new Car("Mercedes", "S63", 7.5, fuelCapacity));

        Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
    }

    [TestCase(0)]
    [TestCase(-10)]
    public void CarRefuelShouldThrowExceptionIfFuelIsNegativeOrZero(double fuelToRefuel)
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(()
            => car.Refuel(fuelToRefuel));

        Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
    }

    [Test]
    public void CarRefuelShouldIncreaseFuelAmount()
    {
        int expectedResult = 10;

        car.Refuel(10);
        double actualResult = car.FuelAmount;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void CarFuelAmountShouldNotBeMoreThanFuelCapacity()
    {
        int expectedResult = 50;

        car.Refuel(65);
        double actualResult = car.FuelAmount;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void CarDriveMethodShouldDecreaseFuelAmount()
    {
        double expectedResult = 9.25;

        car.Refuel(10);
        car.Drive(10);
        double actualResult = car.FuelAmount;

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void CarDriveMethodShouldThrowExceptionIfFuelNeededIsMoreThanFuelAmount()
    {
        car.Refuel(2);

        InvalidOperationException exception = Assert.Throws<InvalidOperationException>(()
            => car.Drive(30));

        Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
    }
}