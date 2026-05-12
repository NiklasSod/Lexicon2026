using Lexicon2026.Exercise_03.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;

namespace Lexicon2026.Exercise_03
{
    internal class Garage(int capacity)
    {
        private readonly Vehicle?[] vehicles = new Vehicle[capacity];

        public static readonly Dictionary<int, string> VehicleTypes = new()
        {
            { 1, "Airplane" },
            { 2, "Bicycle" },
            { 3, "Boat" },
            { 4, "Bus" },
            { 5, "Car" },
            { 6, "Motorcycle" }
        };

        public bool CheckAvailableSpot()
        {
            foreach (Vehicle? vehicle in vehicles)
            {
                if (vehicle == null)
                {
                    return false;
                }
            }
            return true;
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

        public void ParkabGarage()
        {
            Vehicle[] startingVehicles =
            {
                new Bicycle
                {
                    RegistrationNumber = "CR56472",
                    Color = "Red",
                    Wheels = 2,
                    Doors = 0,
                    PackageHolder = false,
                },
                new Car
                {
                    RegistrationNumber = "HEJ745",
                    Color = "Grey",
                    Wheels = 4,
                    Doors = 4,
                    HorsePower = 120,
                },
                new Airplane
                {
                    RegistrationNumber = "PLN123",
                    Color = "White",
                    Wheels = 3,
                    Doors = 6,
                    MaxSpeed = 1200,
                },
                new Boat
                {
                    RegistrationNumber = "BOT456",
                    Color = "Blue",
                    Wheels = 0,
                    Doors = 2,
                    Length = 4.80,
                },
                new Bicycle
                {
                    RegistrationNumber = "BI73389",
                    Color = "Red",
                    Wheels = 2,
                    Doors = 0,
                    PackageHolder = true,
                },
                new Car
                {
                    RegistrationNumber = "JAN719",
                    Color = "Pink",
                    Wheels = 4,
                    Doors = 2,
                    HorsePower = 72,
                },
                new Motorcycle
                {
                    RegistrationNumber = "MOTO789",
                    Color = "Black",
                    Wheels = 2,
                    Doors = 0,
                    CylinderVolume = 250,
                },
                new Bus
                {
                    RegistrationNumber = "SL0001",
                    Color = "Green",
                    Wheels = 8,
                    Doors = 3,
                    Seats = 48
                },
                new Car
                {
                    RegistrationNumber = "COOLAST",
                    Color = "Purple",
                    Wheels = 4,
                    Doors = 2,
                    HorsePower = 272,
                },
                new Motorcycle
                {
                    RegistrationNumber = "TUR6789",
                    Color = "White",
                    Wheels = 2,
                    Doors = 0,
                    CylinderVolume = 250,
                },
            };

            foreach (Vehicle vehicle in startingVehicles)
            {
                AddVehicle(vehicle);
            }

        }

        private void AddVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    return;
                }
            }
        }

        public Vehicle?[] FilterVehicleType(int vehicleTypeKey)
        {
            if (!VehicleTypes.TryGetValue(vehicleTypeKey, out string? typeName))
            {
                return [];
            }
            return [.. vehicles.Where(v => v != null && v.GetType().Name.Equals(typeName))];
        }

        // TODO method? lookup on vehicles with one or more filters, ex: all black vehicles with four tires
    }
}
