using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class TakeVehiclesTests
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
        public void RemoveVehicle_WhenInGarage()
        {
            _garage.ParkVehicle(_bicycle);
            bool removeVehicle = _garage.TakeVehicles("CR56472");

            Assert.True(removeVehicle);
        }

        [Fact]
        public void RemoveVehicle_WhenNotInGarage()
        {
            bool removeVehicle = _garage.TakeVehicles("CR56472");
            Assert.False(removeVehicle);
        }

        [Fact]
        public void RemoveWrongVehicle_WhenOtherVehiclesInGarage()
        {
            _garage.ParkVehicle(_bicycle);
            bool removeVehicle = _garage.TakeVehicles("BIL123");
            Assert.False(removeVehicle);
        }

        [Fact]
        public void RemoveVehicleNoRegNo_WhenVehicleInGarage()
        {
            _garage.ParkVehicle(_bicycle);
            bool removeVehicle = _garage.TakeVehicles("");
            Assert.False(removeVehicle);
        }
    }
}
