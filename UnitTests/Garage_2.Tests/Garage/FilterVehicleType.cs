using Lexicon2026.Garage_2.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class FilterVehicleTypeTests
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
        public void ReturnVehicleFromList_WhenFilterByVehicle()
        {
            _garage.ParkVehicle(_bicycle);
            _garage.ParkVehicle(_car);
            var filteredBicycle = _garage.FilterVehicleType(2);

            Assert.Contains(_bicycle, filteredBicycle);
        }

        [Fact]
        public void ReturnEmpty_WhenFilterByVehicleNotInGarage()
        {
            _garage.ParkVehicle(_car);
            var filteredBicycle = _garage.FilterVehicleType(2);

            Assert.Empty(filteredBicycle);
        }
    }
}
