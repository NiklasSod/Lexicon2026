using Lexicon2026.Garage_2.Utils;
using Lexicon2026.Garage_2.VehicleTypes;
using Lexicon2026.Garage_2.Handlers;
using Lexicon2026.Garage_2.UIs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace Lexicon2026.Garage_2;

public class Program
{
    private static readonly Handler handler = new Handler();
    private static readonly UI ui = new UI();

    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        GarageStart();
        while (GarageUI())
        {
            // runs until GarageUI return false
        }
    }

    private static void GarageStart()
    {
        int userChoice = ui.UIGarageStart();
        if (userChoice == 1)
        {
            int garageSize = ui.GarageSize();
            handler.InitializeGarage(garageSize);
        }
        else
        {
            handler.InitializeGarage(20);
            handler.SeedDefaultGarage();
        }
    }

    private static bool GarageUI()
    {
        int userInput = ui.UIGarageUI();

        switch (userInput)
        {
            case 1:
                if (handler.IsGarageFull())
                {
                    ui.ShowGarageFullMessage();
                    return true;
                }
                string vehicleType = UserVehicle();
                Vehicle vehicle = UserVehicleData(vehicleType);
                handler.ParkVehicle(vehicle);
                return true;
            case 2:
                GetOneVehicle();
                return true;
            case 3:
                CheckVehicles();
                return true;
            case 4:
                FilterVehicles();
                return true;
            case 5:
                return false;
            default:
                return true;
        }
    }

    private static string UserVehicle()
    {
        int vehicleChoice = ui.UserVehicleSelection();

        if (vehicleChoice == 1) return "Car";
        if (vehicleChoice == 2) return "Airplane";
        if (vehicleChoice == 3) return "Bicycle";
        if (vehicleChoice == 4) return "Motorcycle";
        if (vehicleChoice == 5) return "Bus";
        return "Boat";
    }

    private static Vehicle UserVehicleData(string vehicleType)
    {
        (string registrationNumber, string color, int doors, int wheels) = ui.UserVehicleDataSelection(vehicleType, handler);

        if (vehicleType == "Car") return CarData(registrationNumber, color, doors, wheels);

        if (vehicleType == "Airplane") return AirplaneData(registrationNumber, color, doors, wheels);

        if (vehicleType == "Bicycle") return BicycleData(registrationNumber, color, doors, wheels);

        if (vehicleType == "Motorcycle") return MotorcycleData(registrationNumber, color, doors, wheels);

        if (vehicleType == "Bus") return BusData(registrationNumber, color, doors, wheels);

        if (vehicleType == "Boat") return BoatData(registrationNumber, color, doors, wheels);

        throw new NotSupportedException($"Vehicle type '{vehicleType}' is not supported.");
    }

    private static Car CarData(string registrationNumber, string color, int doors, int wheels)
    {
        int horsePower;
        Console.WriteLine("How many horsepowers does the car have?");
        while (true)
        {
            string? inputHorsePower = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputHorsePower) || !int.TryParse(inputHorsePower, out horsePower))
            {
                Console.WriteLine("Try again:");
                continue;
            }
            break;
        }

        Car car = new()
        {
            RegistrationNumber = registrationNumber,
            Color = color,
            Wheels = wheels,
            Doors = doors,
            HorsePower = horsePower,
        };
        return car;
    }

    private static Airplane AirplaneData(string registrationNumber, string color, int doors, int wheels)
    {
        int maxSpeed;
        Console.WriteLine("What is the max speed of this airplane in kilometers?");
        while (true)
        {
            string? inputMaxSpeed = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputMaxSpeed) || !int.TryParse(inputMaxSpeed, out maxSpeed))
            {
                Console.WriteLine("Try again:");
                continue;
            }
            break;
        }

        Airplane airplane = new()
        {
            RegistrationNumber = registrationNumber,
            Color = color,
            Wheels = wheels,
            Doors = doors,
            MaxSpeed = maxSpeed,
        };
        return airplane;
    }

    private static Bicycle BicycleData(string registrationNumber, string color, int doors, int wheels)
    {
        bool packageHolder;
        Console.WriteLine("Does your bicycle have a package holder?");
        Console.WriteLine("Input 1 for yes - 2 for no");
        while (true)
        {
            string? inputPackageHolder = Console.ReadLine();
            if (inputPackageHolder == "1")
            {
                packageHolder = true;
                break;
            }
            if (inputPackageHolder == "2")
            {
                packageHolder = false;
                break;
            }
            Console.WriteLine("Try again:");
        }
        Bicycle bicycle = new()
        {
            RegistrationNumber = registrationNumber,
            Color = color,
            Wheels = wheels,
            Doors = doors,
            PackageHolder = packageHolder,
        };
        return bicycle;
    }

    private static Motorcycle MotorcycleData(string registrationNumber, string color, int doors, int wheels)
    {
        int cylinderVolume;
        Console.WriteLine("What is the cylinder volume of this motorcycle?");
        while (true)
        {
            string? inputCylinderVolume = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputCylinderVolume) || !int.TryParse(inputCylinderVolume, out cylinderVolume))
            {
                Console.WriteLine("Try again:");
                continue;
            }
            break;
        }

        Motorcycle motorcycle = new()
        {
            RegistrationNumber = registrationNumber,
            Color = color,
            Wheels = wheels,
            Doors = doors,
            CylinderVolume = cylinderVolume,
        };
        return motorcycle;
    }

    private static Bus BusData(string registrationNumber, string color, int doors, int wheels)
    {
        int seats;
        Console.WriteLine("How many passangers can sit in this bus?");
        while (true)
        {
            string? inputSeats = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputSeats) || !int.TryParse(inputSeats, out seats))
            {
                Console.WriteLine("Try again:");
                continue;
            }
            break;
        }

        Bus bus = new()
        {
            RegistrationNumber = registrationNumber,
            Color = color,
            Wheels = wheels,
            Doors = doors,
            Seats = seats,
        };
        return bus;
    }

    private static Boat BoatData(string registrationNumber, string color, int doors, int wheels)
    {
        double length;
        Console.WriteLine("How long is this boat in meters? \nEx: 4.20 for 4 meters and 20 centimeters");
        while (true)
        {
            string? inputLengt = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(inputLengt) || !double.TryParse(inputLengt, System.Globalization.CultureInfo.InvariantCulture, out length))
            {
                Console.WriteLine("Try again:");
                continue;
            }
            break;
        }

        Boat Boat = new()
        {
            RegistrationNumber = registrationNumber,
            Color = color,
            Wheels = wheels,
            Doors = doors,
            Length = length
        };
        return Boat;
    }

    private static void CheckVehicles()
    {
        Vehicle?[] allVehicles = handler.GetAllVehicles();
        DisplayVehicles(allVehicles);
    }

    private static void DisplayVehicles(Vehicle?[] vehicles)
    {
        Console.Clear();
        bool empty = true;

        foreach (Vehicle? vehicle in vehicles)
        {
            if (vehicle != null)
            {
                empty = false;
                if (vehicle is Car car) Console.WriteLine(car.ToString());
                if (vehicle is Bicycle bicycle) Console.WriteLine(bicycle.ToString());
                if (vehicle is Airplane airplane) Console.WriteLine(airplane.ToString());
                if (vehicle is Motorcycle motorcycle) Console.WriteLine(motorcycle.ToString());
                if (vehicle is Bus bus) Console.WriteLine(bus.ToString());
                if (vehicle is Boat boat) Console.WriteLine(boat.ToString());
                Console.WriteLine("----------------------");
            }
        }

        if (empty)
        {
            Console.WriteLine("Garage is empty.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    private static void GetOneVehicle()
    {
        Console.Clear();
        Vehicle?[] vehicles = handler.GetAllVehicles();
        Console.WriteLine("Whats the registration number?");
        string? registrationNumber;
        while (true)
        {
            Console.WriteLine("Input 'return' to return to the main menu");
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid registration number, try again");
                continue;
            }
            registrationNumber = input;
            if (registrationNumber.Length < 6)
            {
                Console.WriteLine("Invalid registration number, at least 6 characters, try again");
                continue;
            }
            if (input == "return")
            {
                GarageUI();
                return;
            }
            if (handler.RemoveVehicle(registrationNumber))
            {
                break;
            }
            else continue;
        }
        Console.WriteLine("Here is your vehicle! Press any key");
        Console.ReadKey();
    }

    private static void FilterVehicles()
    {
        Console.Clear();
        if (handler.IsGarageEmpty())
        {
            Console.WriteLine("The garage is empty");
            Console.WriteLine("Returning you to the main menu...");
            Thread.Sleep(2500);
            return;
        }

        Vehicle?[] vehicles = handler.GetAllVehicles();
        Console.WriteLine("What do you want to filter around?");
        Console.WriteLine("1: Vehicle type.\n2: Number of doors.\n3: Number of wheels.");
        int maxFilter = 3;
        int userChoice = InputHandler.GetValidatedNumber(1, maxFilter, $"Invalid input, Choose a number between 1 and {maxFilter}:");
        Console.WriteLine("Lets try to see if what you want more information about is here.");
        switch (userChoice)
        {
            case 1:
                Console.WriteLine("1: Airplane.\n2: Bicycle.\n3: Boat.\n4: Bus.\n5: Car.\n6: Motorcycle.");
                int maxVehicle = 6;
                int userVehicleChoice = InputHandler.GetValidatedNumber(1, maxVehicle, $"Invalid input, Choose a number between 1 and {maxVehicle}:");
                Vehicle?[] filteredByVehicle = handler.FilterByVehicleType(userVehicleChoice);
                DisplayVehicles(filteredByVehicle);
                break;
            case 2:
                Console.WriteLine("How many doors are you filtering for?");
                int maxDoors = 100;
                int userDoorChoice = InputHandler.GetValidatedNumber(0, maxDoors, $"Invalid input, Choose a number between 1 and {maxDoors}:");
                Vehicle?[] filteredByDoor = handler.FilterVehicleByKey(userDoorChoice, "doors");
                DisplayVehicles(filteredByDoor);
                break;
            case 3:
                Console.WriteLine("How many wheels are you filtering for?");
                int maxWheels = 100;
                int userWheelChoice = InputHandler.GetValidatedNumber(0, maxWheels, $"Invalid input, Choose a number between 1 and {maxWheels}:");
                Vehicle?[] filteredByWheel = handler.FilterVehicleByKey(userWheelChoice, "wheels");
                DisplayVehicles(filteredByWheel);
                break;
            default:
                break;
        }
    }
}
