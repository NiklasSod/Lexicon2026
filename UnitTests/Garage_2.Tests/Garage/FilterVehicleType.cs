using Lexicon2026.Garage_2.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class FilterVehicleTypeTests
    {
        [Fact]
        public void ReturnVehicleFromList_WhenFilterByVehicle()
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
            var filteredBicycle = garage.FilterVehicleType(2);

            Assert.Contains(bicycle, filteredBicycle);
        }

        [Fact]
        public void ReturnEmpty_WhenFilterByVehicleNotInGarage()
        {
            var garage = new Garage<Vehicle>(2);
            Vehicle car = new Car
            {
                RegistrationNumber = "BIL456",
                Color = "Green",
                Wheels = 4,
                Doors = 4,
                HorsePower = 125,
            };
            garage.ParkVehicle(car);
            var filteredBicycle = garage.FilterVehicleType(2);

            Assert.Empty(filteredBicycle);
        }
    }
}
