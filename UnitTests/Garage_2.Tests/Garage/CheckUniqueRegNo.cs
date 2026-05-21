using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class CheckUniqueRegNoTests
    {
        private readonly Garage<Vehicle> _garage = new Garage<Vehicle>(1);

        private readonly Vehicle _bicycle = new Bicycle
        {
            RegistrationNumber = "CR56472",
            Color = "Red",
            Wheels = 2,
            Doors = 0,
            PackageHolder = false,
        };

        [Fact]
        public void RegNoFound_WhenGarageHasCorrectVehicle()
        {
            _garage.ParkVehicle(_bicycle);
            bool foundVehicle = _garage.CheckUniqueRegNo("CR56472");

            Assert.True(foundVehicle);
        }

        [Fact]
        public void RegNoNotFound_WhenNotInGarage()
        {
            bool foundVehicle = _garage.CheckUniqueRegNo("CR56472");

            Assert.False(foundVehicle);
        }

        [Fact]
        public void NoInputRegNo_WhenInGarage()
        {

            _garage.ParkVehicle(_bicycle);
            bool foundVehicle = _garage.CheckUniqueRegNo("");

            Assert.False(foundVehicle);
        }
    }
}
