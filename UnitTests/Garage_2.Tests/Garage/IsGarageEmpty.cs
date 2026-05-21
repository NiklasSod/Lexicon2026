using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class IsGarageEmptyTests
    {
        [Fact]
        public void EmptyGarage_WhenGarageIsEmpty()
        {
            var garage = new Garage<Vehicle>(1);
            bool GarageIsEmpty = garage.IsGarageEmpty();

            Assert.True(GarageIsEmpty);
        }

        [Fact]
        public void NotEmptyGarage_WhenGarageHasAnyVehicle()
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
            bool GarageIsEmpty = garage.IsGarageEmpty();

            Assert.False(GarageIsEmpty);
        }
    }
}
