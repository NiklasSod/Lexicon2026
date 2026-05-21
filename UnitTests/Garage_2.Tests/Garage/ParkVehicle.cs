using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class ParkVehicleTests
    {
        [Fact]
        public void ParkVehicle_WhenGarageIsAvailable_ReturnTrue()
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
            bool vehicleParked = garage.ParkVehicle(bicycle);

            Assert.True(vehicleParked);
        }

        [Fact]
        public void ParkNull_WhenGarageIsAvailable_ReturnFalse()
        {
            var garage = new Garage<Vehicle>(1);

            bool nullParked = garage.ParkVehicle(null!);

            Assert.False(nullParked);
        }

        [Fact]
        public void ParkVehicle_WhenGarageIsFull_ReturnFalse()
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
            Vehicle car = new Car
            {
                RegistrationNumber = "BIL456",
                Color = "Green",
                Wheels = 4,
                Doors = 4,
                HorsePower = 125,
            };

            garage.ParkVehicle(bicycle);
            bool isParked = garage.ParkVehicle(car);

            Assert.False(isParked);
        }
    }
}
