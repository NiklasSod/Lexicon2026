using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class IsGarageEmptyTests
    {
        private readonly Garage<Vehicle> _garage = new Garage<Vehicle>(1);

        [Fact]
        public void GarageIsEmpty_WhenNoVehiclesAreParked()
        {
            bool GarageIsEmpty = _garage.IsGarageEmpty();

            Assert.True(GarageIsEmpty);
        }

        [Fact]
        public void GarageIsEmpty_WhenGarageHasAnyVehicle()
        {
            Vehicle bicycle = new Bicycle
            {
                RegistrationNumber = "CR56472",
                Color = "Red",
                Wheels = 2,
                Doors = 0,
                PackageHolder = false,
            };

            _garage.ParkVehicle(bicycle);
            bool GarageIsEmpty = _garage.IsGarageEmpty();

            Assert.False(GarageIsEmpty);
        }
    }
}
