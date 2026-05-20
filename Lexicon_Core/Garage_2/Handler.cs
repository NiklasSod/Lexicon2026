using Lexicon2026.Exercise_03;
using Lexicon2026.Garage_2.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2
{
    public class Handler : IHandler
    {
        private Garage<Vehicle> _garage = null!;

        public void InitializeGarage(int capacity)
        {
            _garage = new Garage<Vehicle>(capacity);
        }

        public void SeedDefaultGarage()
        {
            _garage.ParkabGarage();
        }

        public bool IsGarageFull() => !_garage.GarageHasAvailableParking();
        public bool IsGarageEmpty() => _garage.IsGarageEmpty();

        public bool RegistrationNumberExists(string registrationNumber)
        {
            return _garage.CheckUniqueRegNo(registrationNumber);
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            return _garage.ParkVehicle(vehicle);
        }

        public bool RemoveVehicle(string registrationNumber)
        {
            return _garage.TakeVehicles(registrationNumber);
        }

        public Vehicle?[] GetAllVehicles()
        {
            return _garage?.GetVehicles() ?? [];
        }

        public Vehicle?[] FilterByVehicleType(int vehicleTypeKey)
        {
            return _garage.FilterVehicleType(vehicleTypeKey);
        }

        public Vehicle?[] FilterVehicleByKey(int userAmount, string vehicleKey)
        {
            return _garage.FilterVehicleByKey(userAmount, vehicleKey);
        }
    }
}
