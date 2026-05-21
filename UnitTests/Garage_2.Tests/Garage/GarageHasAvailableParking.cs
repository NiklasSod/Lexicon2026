using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class GarageHasAvailableParkingTests
    {
        [Fact]
        public void ParkingIsPossible_WhenGarageHasAvailableParking()
        {
            var garage = new Garage<Vehicle>(1);
            bool hasParking = garage.GarageHasAvailableParking();

            Assert.True(hasParking);
        }

        [Fact]
        public void ParkingIsPossible_WhenGarageHasNoAvailableParking()
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
            bool hasParking = garage.GarageHasAvailableParking();

            Assert.False(hasParking);
        }
    }
}