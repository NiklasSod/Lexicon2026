using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class ParkVehicleTests
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

        private readonly Vehicle _car = new Car
        {
            RegistrationNumber = "BIL456",
            Color = "Green",
            Wheels = 4,
            Doors = 4,
            HorsePower = 125,
        };

        [Fact]
        public void ParkVehicle_WhenGarageIsAvailable()
        {
            bool vehicleParked = _garage.ParkVehicle(_bicycle);
            Assert.True(vehicleParked);
        }

        [Fact]
        public void ParkNull_WhenGarageIsAvailable()
        {
            bool nullParked = _garage.ParkVehicle(null!);
            Assert.False(nullParked);
        }

        [Fact]
        public void ParkVehicle_WhenGarageIsFull()
        {
            _garage.ParkVehicle(_bicycle);
            bool isParked = _garage.ParkVehicle(_car);

            Assert.False(isParked);
        }
    }
}
