using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_03
{
    internal class Garage(int capacity)
    {
        private readonly Vehicle?[] vehicles = new Vehicle[capacity];

        public void ParkVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    Console.WriteLine($"\nParked: {vehicle.GetType().Name}");
                    Console.WriteLine("Press any button");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("Garage is full. Cannot park vehicle.");
            Console.WriteLine("Press any button");
            Console.ReadKey();
        }

        public Vehicle?[] GetVehicles()
        {
            return vehicles;
        }

        public bool CheckUniqueRegNo(string registrationNumber)
        {
            foreach (Vehicle? vehicle in vehicles) {
                if (vehicle != null && vehicle.RegistrationNumber.Equals(
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool TakeVehicles(string registrationNumber)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                Vehicle? vehicle = vehicles[i];
                if (vehicle != null && vehicle.RegistrationNumber.Equals(
                    registrationNumber,
                    StringComparison.OrdinalIgnoreCase))
                {
                    vehicles[i] = null;

                    Console.WriteLine("\nVehicle removed from garage.");
                    return true;
                }
            }
            Console.WriteLine("Vehicle not found.");
            return false;
        }

        // TODO method? lookup on vehicles with one or more filters, ex: all black vehicles with four tires

        // TODO method to view vehicle type and amount
    }
}
