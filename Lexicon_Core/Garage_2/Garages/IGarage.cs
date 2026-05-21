using Lexicon2026.Garage_2.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.Garages
{
    internal interface IGarage<T> : IEnumerable<T> where T : Vehicle
    {
        // Properties / State Checks
        bool GarageHasAvailableParking();
        bool IsGarageEmpty();

        // Core Actions
        bool ParkVehicle(T vehicle);
        bool TakeVehicles(string registrationNumber);

        // Queries & Data Retrieval
        IEnumerable<T> GetVehicles();
        bool CheckUniqueRegNo(string registrationNumber);
        T?[] FilterVehicleType(int vehicleTypeKey);
        T?[] FilterVehicleByKey(int userAmount, string vehicleKey);

        // Seed Method
        void ParkabGarage();
    }
}