using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class ParkabGarageTests
    {
        [Fact]
        public void ParkabGarage_ShouldAddTenVehiclesToTheGarage()
        {
            var garage = new Garage<Vehicle>(10);
            garage.ParkabGarage();
            var vehicles = garage.GetVehicles().ToArray();

            Assert.Equal(10, vehicles.Length);
        }

        [Fact]
        public void ParkabGarage_ShouldMakeGarageFullWhenAddingAllParking()
        {
            var garage = new Garage<Vehicle>(10);
            garage.ParkabGarage();

            Assert.False(garage.GarageHasAvailableParking());
        }
    }
}
