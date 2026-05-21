using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;

namespace UnitTests.Garage_2.Tests.Garage
{
    public class ParkabGarageTests
    {
        private readonly Garage<Vehicle> _garage = new Garage<Vehicle>(10);

        [Fact]
        public void ParkabGarage_ShouldAddTenVehiclesToTheGarage()
        {
            _garage.ParkabGarage();
            var vehicles = _garage.GetVehicles().ToArray();

            Assert.Equal(10, vehicles.Length);
        }

        [Fact]
        public void ParkabGarage_ShouldMakeGarageFullWhenAddingAllParking()
        {
            _garage.ParkabGarage();

            Assert.False(_garage.GarageHasAvailableParking());
        }
    }
}
