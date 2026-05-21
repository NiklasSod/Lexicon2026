using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class TakeVehiclesTests
    {
        [Fact]
        public void RemoveVehicle_WhenInGarage()
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
            bool removeVehicle = garage.TakeVehicles("CR56472");

            Assert.True(removeVehicle);
        }

        [Fact]
        public void RemoveVehicle_WhenNotInGarage()
        {
            var garage = new Garage<Vehicle>(1);
            bool removeVehicle = garage.TakeVehicles("CR56472");

            Assert.False(removeVehicle);
        }

        [Fact]
        public void RemoveWrongVehicle_WhenOtherVehiclesInGarage()
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
            bool removeVehicle = garage.TakeVehicles("BIL123");

            Assert.False(removeVehicle);
        }

        [Fact]
        public void RemoveVehicleNoRegNo_WhenVehicleInGarage()
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
            bool removeVehicle = garage.TakeVehicles("");

            Assert.False(removeVehicle);
        }
    }
}
