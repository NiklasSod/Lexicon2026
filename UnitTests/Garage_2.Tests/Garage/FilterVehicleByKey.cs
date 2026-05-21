using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class FilterVehicleByKeyTests
    {
        private readonly Garage<Vehicle> _garage = new Garage<Vehicle>(2);

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
        public void ReturnVehicleFromList_WhenFilterByDoors()
        {
            _garage.ParkVehicle(_bicycle);
            _garage.ParkVehicle(_car);
            var filteredByDoors = _garage.FilterVehicleByKey(4, "doors");

            Assert.Single(filteredByDoors);
        }

        [Fact]
        public void ReturnVehicleFromList_WhenFilterByWheels()
        {
            _garage.ParkVehicle(_bicycle);
            _garage.ParkVehicle(_car);
            var filteredByWheels = _garage.FilterVehicleByKey(2, "wheels");


            Assert.Single(filteredByWheels);
        }

        [Fact]
        public void ReturnEmpty_WhenFilterByKeyNotInGarage()
        {
            _garage.ParkVehicle(_bicycle);

            Assert.Empty(_garage.FilterVehicleByKey(2, "doors"));
        }
    }
}
