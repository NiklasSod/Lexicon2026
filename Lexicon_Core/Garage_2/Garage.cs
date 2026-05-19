using Lexicon2026.Exercise_03;
using Lexicon2026.Garage_2.VehicleTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;

namespace Lexicon2026.Garage_2;

internal class Garage<T> : IGarage<T> where T : Vehicle
{
    private readonly T?[] vehicles;

    public Garage(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("Capacity must be greater than zero.");
        }

        vehicles = new T[capacity];
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var vehicle in vehicles)
        {
            if (vehicle != null)
            {
                yield return vehicle;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public static readonly Dictionary<int, string> VehicleTypes = new()
    {
        { 1, "Airplane" },
        { 2, "Bicycle" },
        { 3, "Boat" },
        { 4, "Bus" },
        { 5, "Car" },
        { 6, "Motorcycle" }
    };

    public bool GarageHasAvailableParking()
    {
        foreach (Vehicle? vehicle in vehicles)
        {
            if (vehicle == null)
            {
                return true;
            }
        }
        return false;
    }

    public bool IsGarageEmpty()
    {
        foreach (Vehicle? vehicle in vehicles)
        {
            if (vehicle != null)
            {
                return false;
            }
        }
        return true;
    }

    public bool ParkVehicle(T vehicle)
    {
        if (vehicle == null)
        {
            Console.WriteLine("Invalid vehicle data.");
            return false;
        }

        for (int i = 0; i < vehicles.Length; i++)
        {
            if (vehicles[i] == null)
            {
                vehicles[i] = vehicle;
                Console.WriteLine($"\nParked: {vehicle.GetType().Name}");
                return true;
            }
        }

        Console.WriteLine("Garage is full. Cannot park vehicle.");
        return false;
    }

    public T?[] GetVehicles()
    {
        return vehicles;
    }

    public bool CheckUniqueRegNo(string registrationNumber)
    {
        foreach (Vehicle? vehicle in vehicles)
        {
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
            AddVehicle((T)vehicle);
        }
    }

    private void AddVehicle(T vehicle)
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

    public T?[] FilterVehicleType(int vehicleTypeKey)
    {
        if (!VehicleTypes.TryGetValue(vehicleTypeKey, out string? typeName))
        {
            return [];
        }
        return [.. vehicles.Where(v => v != null && v.GetType().Name.Equals(typeName))];
    }

    public T?[] FilterVehicleByKey(int userAmount, string vehicleKey)
    {
        return [.. vehicles
            .Where(v => v != null && (vehicleKey.ToLower() switch
            {
                "doors" => v.Doors == userAmount,
                "wheels" => v.Wheels == userAmount,
                _ => false
            }))];
    }
}
