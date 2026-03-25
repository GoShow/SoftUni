using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NUnit.Framework;

namespace AutoTrade.Tests
{
    [TestFixture]
    public class DealerShopTests
    {
        [Test]
        public void ConstructorShouldInitializeWithValidCapacity()
        {
            DealerShop dealerShop = new(3);

            Assert.AreEqual(3, dealerShop.Capacity);
            Assert.IsNotNull(dealerShop.Vehicles);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void ConstructorShouldThrowExceptionWhenCapacityIsZeroOrLess(int capacity)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => new DealerShop(capacity));

            Assert.AreEqual("Capacity must be a positive value.", ex.Message);
        }

        [Test]
        public void AddVehicleShouldAddWhenShopNotFull()
        {
            DealerShop dealerShop = new(2);

            Vehicle vehicle = new("BMW", "323", 1982);

            string actual = dealerShop.AddVehicle(vehicle);

            Assert.AreEqual(1, dealerShop.Vehicles.Count);
            Assert.AreEqual("Added 1982 BMW 323", actual);
        }

        [Test]
        public void AddVehicleShouldThrowExceptionWhenShopIsFull()
        {
            DealerShop dealerShop = new(1);

            Vehicle vehicle1 = new("BMW", "323", 1982);
            Vehicle vehicle2 = new("BMW", "525", 1984);

            string actual = dealerShop.AddVehicle(vehicle1);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(
                () => dealerShop.AddVehicle(vehicle2));

            Assert.AreEqual("Inventory is full", ex.Message);
        }

        [Test]
        public void SellVehicleShouldReturnTrueWhenVehicleFound()
        {
            DealerShop dealerShop = new(1);
            Vehicle vehicle = new("BMW", "323", 1982);

            dealerShop.AddVehicle(vehicle);

            bool actual = dealerShop.SellVehicle(vehicle);

            Assert.IsTrue(actual);
            Assert.AreEqual(0, dealerShop.Vehicles.Count);
        }

        [Test]
        public void SellVehicleShouldReturnFalseWhenVehicleNotFound()
        {
            DealerShop dealerShop = new(12);
            Vehicle vehicle = new("BMW", "323", 1982);

            bool actual = dealerShop.SellVehicle(vehicle);

            Assert.False(actual);
        }

        [Test]
        public void InventoryReportReturnsCorrectReport()
        {
            DealerShop dealerShop = new(12);
            Vehicle vehicle1 = new("BMW", "323", 1982);
            Vehicle vehicle2 = new("BMW", "525", 1984);

            dealerShop.AddVehicle(vehicle1);
            dealerShop.AddVehicle(vehicle2);

            string actualReport = dealerShop.InventoryReport();

            StringBuilder expectedReport = new();
            expectedReport.AppendLine("Inventory Report");
            expectedReport.AppendLine($"Capacity: 12");
            expectedReport.AppendLine($"Vehicles: 2");
            expectedReport.AppendLine($"1982 BMW 323");
            expectedReport.AppendLine($"1984 BMW 525");

            Assert.AreEqual(expectedReport.ToString().TrimEnd(), actualReport);

        }
    }
}
