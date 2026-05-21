using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class FilterVehicleByKeyTests
    {
        [Fact]
        public void ReturnVehicleFromList_WhenFilterByDoors()
        {
            var garage = new Garage<Vehicle>(2);
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
            var filteredByDoors = garage.FilterVehicleByKey(4, "doors");

            Assert.Single(filteredByDoors);
        }

        [Fact]
        public void ReturnVehicleFromList_WhenFilterByWheels()
        {
            var garage = new Garage<Vehicle>(2);
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
            var filteredByWheels = garage.FilterVehicleByKey(2, "wheels");


            Assert.Single(filteredByWheels);
        }

        [Fact]
        public void ReturnEmpty_WhenFilterByKeyNotInGarage()
        {
            var garage = new Garage<Vehicle>(2);
            Vehicle bicycle = new Bicycle
            {
                RegistrationNumber = "CR56472",
                Color = "Red",
                Wheels = 2,
                Doors = 0,
                PackageHolder = false,
            };
            garage.ParkVehicle(bicycle);

            Assert.Empty(garage.FilterVehicleByKey(2, "doors"));
        }
    }
}
