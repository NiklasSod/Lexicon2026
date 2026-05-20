using Lexicon2026.Garage_2.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.Handlers
{
    public interface IHandler
    {
        // Setup and State
        void InitializeGarage(int capacity);
        void SeedDefaultGarage();
        bool IsGarageFull();
        bool IsGarageEmpty();

        // Core Operations
        bool ParkVehicle(Vehicle vehicle);
        bool RemoveVehicle(string registrationNumber);
        bool RegistrationNumberExists(string registrationNumber);

        // Queries and Formatting (Decoupling UI from Domain Objects)
        Vehicle?[] GetAllVehicles();
        Vehicle?[] FilterByVehicleType(int vehicleTypeKey);
        Vehicle?[] FilterVehicleByKey(int userAmount, string vehicleKey);
    }
}
