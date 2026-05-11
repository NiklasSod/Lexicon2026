using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_03
{
    internal class Garage
    {
        private readonly Vehicle?[] vehicles;

        public Garage(int capacity)
        {
            vehicles = new Vehicle[capacity];
        }

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

        public Vehicle[] GetVehicles()
        {
            return vehicles;
        }

        public bool TakeVehicles(string registrationNumber)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] != null &&
                    vehicles[i].RegistrationNumber.ToLower() == registrationNumber.ToLower())
                {
                    vehicles[i] = null;

                    Console.WriteLine("\nVehicle removed from garage.");
                    return true;
                }
            }
            Console.WriteLine("Vehicle not found.");
            return false;
        }

        // method? lookup on vehicles with one or more filters, ex: all black vehicles with four tires

        // method to view vehicle type and amount
    }
}
