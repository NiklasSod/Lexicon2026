using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class CheckUniqueRegNoTests
    {
        [Fact]
        public void RegNoFound_WhenGarageHasCorrectVehicle()
        {
            var garage = new Garage<Vehicle>(1);
            Vehicle bicycle = new Bicycle
            {
                RegistrationNumber = "CR56472",
                Color = "Red",
                Wheels = 2,
                Doors = 0,
                PackageHolder = false,
            };

            garage.ParkVehicle(bicycle);
            bool foundVehicle = garage.CheckUniqueRegNo("CR56472");

            Assert.True(foundVehicle);
        }

        [Fact]
        public void RegNoNotFound_WhenNotInGarage()
        {
            var garage = new Garage<Vehicle>(1);
            bool foundVehicle = garage.CheckUniqueRegNo("CR56472");

            Assert.False(foundVehicle);
        }

        [Fact]
        public void NoInputRegNo_WhenInGarage()
        {
            var garage = new Garage<Vehicle>(1);
            Vehicle bicycle = new Bicycle
            {
                RegistrationNumber = "CR56472",
                Color = "Red",
                Wheels = 2,
                Doors = 0,
                PackageHolder = false,
            };

            garage.ParkVehicle(bicycle);
            bool foundVehicle = garage.CheckUniqueRegNo("");

            Assert.False(foundVehicle);
        }
    }
}
