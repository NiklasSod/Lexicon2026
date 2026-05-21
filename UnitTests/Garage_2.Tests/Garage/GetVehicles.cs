using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class GetVehiclesTests
    {
        [Fact]
        public void ListOfVehicle_WhenNothingIsParked()
        {
            var garage = new Garage<Vehicle>(5);

            Vehicle[] vehicles = [.. garage.GetVehicles()];

            Assert.Empty(vehicles);
        }

        [Fact]
        public void ListOfVehicle_WhenVehicleIsParked()
        {
            var garage = new Garage<Vehicle>(5);
            Vehicle bicycle = new Bicycle
            {
                RegistrationNumber = "CR56472",
                Color = "Red",
                Wheels = 2,
                Doors = 0,
                PackageHolder = false,
            };

            garage.ParkVehicle(bicycle);
            Vehicle[] vehicles = [.. garage.GetVehicles()];

            Assert.Single(vehicles);
            Assert.Contains(bicycle, vehicles);
        }

        [Fact]
        public void ListOfVehicles_WhenVehiclesAreParked()
        {
            var garage = new Garage<Vehicle>(5);
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
            garage.ParkVehicle(car);
            Vehicle[] vehicles = [.. garage.GetVehicles()];

            Assert.Equal(2, vehicles.Length);
            Assert.Collection(vehicles,
                item1 => Assert.Same(bicycle, item1),
                item2 => Assert.Same(car, item2)
);
        }
    }
}
