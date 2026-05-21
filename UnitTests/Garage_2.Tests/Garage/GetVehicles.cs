using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class GetVehiclesTests
    {
        private readonly Garage<Vehicle> _garage = new Garage<Vehicle>(5);

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
        public void ListOfVehicle_WhenNothingIsParked()
        {
            Vehicle[] vehicles = [.. _garage.GetVehicles()];

            Assert.Empty(vehicles);
        }

        [Fact]
        public void ListOfVehicle_WhenVehicleIsParked()
        {
            _garage.ParkVehicle(_bicycle);
            Vehicle[] vehicles = [.. _garage.GetVehicles()];

            Assert.Single(vehicles);
            Assert.Contains(_bicycle, vehicles);
        }

        [Fact]
        public void ListOfVehicles_WhenVehiclesAreParked()
        {
            _garage.ParkVehicle(_bicycle);
            _garage.ParkVehicle(_car);
            Vehicle[] vehicles = [.. _garage.GetVehicles()];

            Assert.Equal(2, vehicles.Length);
            Assert.Collection(vehicles,
                item1 => Assert.Same(_bicycle, item1),
                item2 => Assert.Same(_car, item2)
            );
        }
    }
}
