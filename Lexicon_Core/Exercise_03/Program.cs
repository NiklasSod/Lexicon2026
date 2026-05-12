using Lexicon2026.Exercise_03.Utils;
using Lexicon2026.Exercise_03.VehicleTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;

namespace Lexicon2026.Exercise_03
{
    public class Program
    {
        private static Garage garage = null!;

        public static void Main()
        {
            GarageStart();
            while (GarageUI())
            {
                // runs until GarageUI return false
            }
        }

        private static void GarageStart()
        {
            Console.WriteLine("Do you want to build a garage or come to a half full one with 10 free spots left?");
            Console.WriteLine("1: I build it from scratch!");
            Console.WriteLine("2: Let me see the existing one.");
            int userChoice = InputHandler.GetValidatedNumber(1, 2, "Invalid input, Choose a number between 1 and 2:");
            Console.Clear();
            if (userChoice == 1)
            {
                int garageSize = GarageSize();
                garage = new Garage(garageSize);
            } else {
                garage = new Garage(20);
                garage.ParkabGarage();
            }
        }

        private static int GarageSize()
        {
            Console.WriteLine("How many parking spots do you need in the garage? \nChoose a number between 1 - 1000");
            return InputHandler.GetValidatedNumber(1, 1000, "Invalid input, Choose a number between 1 and 1000:");
        }

        private static bool GarageUI()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the garage, select what to do by pressing the corresponding number:\n");
            Console.WriteLine("1: Park a vehicle");
            Console.WriteLine("2: Take out a vehicle");
            Console.WriteLine("3: Lookup on a vehicle");
            Console.WriteLine("4: Look for a vehicle based on filter");
            //Console.WriteLine("5: ???");
            Console.WriteLine("5: Exit program"); // 6

            int userInput = InputHandler.GetValidatedNumber(1, 5, "Invalid input, Choose a number between 1 and 5:");

            switch (userInput)
            {
                case 1:
                    if (garage.CheckAvailableSpot())
                    {
                        Console.Clear();
                        Console.WriteLine("Garage is at full capacity \nPress anything to return to the main menu");
                        Console.ReadKey();
                        return true;
                    }
                    string vehicleType = UserVehicle();
                    Vehicle vehicle = UserVehicleData(vehicleType);
                    garage.ParkVehicle(vehicle);
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
                //case 5:
                //    FilterVehiclesOnKey();
                //    return true;
                case 5: // 6
                    return false;
                default:
                    return true;
            }
        }

        private static string UserVehicle()
        {
            Console.Clear();
            Console.WriteLine("What vehicle type do you park?\n");
            Console.WriteLine("1: Car");
            Console.WriteLine("2: Airplane");
            Console.WriteLine("3: Bicycle");
            Console.WriteLine("4: Motorcycle");
            Console.WriteLine("5: Bus");
            Console.WriteLine("6: Boat");

            int max = 6;
            int vehicleChoice = InputHandler.GetValidatedNumber(1, max, $"Invalid input, Choose a number between 1 and {max}:");

            if (vehicleChoice == 1) return "Car";
            if (vehicleChoice == 2) return "Airplane";
            if (vehicleChoice == 3) return "Bicycle";
            if (vehicleChoice == 4) return "Motorcycle";
            if (vehicleChoice == 5) return "Bus";
            return "Boat";
        }

        private static Vehicle UserVehicleData(string vehicleType)
        {
            Console.Clear();
            Console.WriteLine($"Great choice, some questions around your {vehicleType.ToLower()}:");

            Console.WriteLine("What is the registration number?");
            int minReg = 6;
            int maxReg = 30;
            string registrationNumber = InputHandler.GetValidatedString(
                garage,
                minReg, 
                maxReg, 
                $"Invalid registration number, at least {minReg} characters (max {maxReg}), try again",
                true);

            Console.WriteLine($"What color does the {vehicleType.ToLower()} have?");
            int minColor = 2;
            int maxColor = 24;
            string color = InputHandler.GetValidatedString(
                garage,
                minColor,
                maxColor,
                $"Invalid registration number, at least {minColor} characters (max {maxColor}), try again");

            Console.WriteLine($"Does the {vehicleType.ToLower()} have doors, how many? (Enter 0 for no)");
            int minDoors = 0;
            int maxDoors = 100;
            int doors = InputHandler.GetValidatedNumber(
                minDoors, 
                maxDoors, 
                $"Invalid input, Choose a number between {minDoors} and {maxDoors}:");

            Console.WriteLine($"Does the {vehicleType.ToLower()} have wheels, how many? (Enter 0 for no)");
            int minWheels = 0;
            int maxWheels = 100;
            int wheels = InputHandler.GetValidatedNumber(
                minWheels,
                maxWheels,
                $"Invalid input, Choose a number between {minWheels} and {maxWheels}:");

            if (vehicleType == "Car")
            {
                return CarData(registrationNumber, color, doors, wheels);
            }

            if (vehicleType == "Airplane")
            {
                return AirplaneData(registrationNumber, color, doors, wheels);
            }

            if (vehicleType == "Bicycle")
            {
                return BicycleData(registrationNumber, color, doors, wheels);
            }

            if (vehicleType == "Motorcycle")
            {
                return MotorcycleData(registrationNumber, color, doors, wheels);
            }

            if (vehicleType == "Bus")
            {
                return BusData(registrationNumber, color, doors, wheels);
            }

            if (vehicleType == "Boat")
            {
                return BoatData(registrationNumber, color, doors, wheels);
            }

            throw new NotSupportedException($"Vehicle type '{vehicleType}' is not supported.");
        }

        private static Car CarData(string registrationNumber, string color, int doors, int wheels) {
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
            Vehicle?[] allVehicles = garage.GetVehicles();
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
                    Console.WriteLine($"Type: {vehicle.GetType().Name}");
                    Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}");
                    Console.WriteLine($"Color: {vehicle.Color}");
                    if (vehicle.Wheels > 0) Console.WriteLine($"Wheels: {vehicle.Wheels}");
                    if (vehicle.Doors > 0) Console.WriteLine($"Doors: {vehicle.Doors}");

                    if (vehicle is Car car)
                    {
                        Console.WriteLine($"Horse powers: {car.HorsePower}");
                    }

                    if (vehicle is Bicycle bicycle)
                    {
                        Console.WriteLine($"Package holder: {bicycle.PackageHolder}");
                    }

                    if (vehicle is Airplane airplane)
                    {
                        Console.WriteLine($"Max speed: {airplane.MaxSpeed}");
                    }

                    if (vehicle is Motorcycle motorcycle)
                    {
                        Console.WriteLine($"Cylinder volume: {motorcycle.CylinderVolume}");
                    }

                    if (vehicle is Bus bus)
                    {
                        Console.WriteLine($"Passanger seat amount: {bus.Seats}");
                    }

                    if (vehicle is Boat boat)
                    {
                        Console.WriteLine($"Boat length: {boat.Length} meters");
                    }

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
            Vehicle?[] vehicles = garage.GetVehicles();
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
                if (garage.TakeVehicles(registrationNumber))
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
            if (garage.CheckAvailableSpot())
            {
                Console.WriteLine("The garage is empty");
                Console.WriteLine("Returning you to the main menu...");
                Thread.Sleep(2500);
                return;
            }

            Vehicle?[] vehicles = garage.GetVehicles();
            Console.WriteLine("What do you want to filter around?");
            Console.WriteLine("1: Vehicle type.\n2: Number of doors.\n3: Number of wheels.");
            int maxFilter = 3;
            int userChoice = InputHandler.GetValidatedNumber(1, maxFilter, $"Invalid input, Choose a number between 1 and {maxFilter}:");
            switch (userChoice)
            {
                case 1:
                    Console.WriteLine("Lets try to see if what you want more information about is here.");
                    Console.WriteLine("1: Airplane.\n2: Bicycle.\n3: Boat.\n4: Bus.\n5: Car.\n6: Motorcycle.");
                    int maxVehicle = 6;
                    int userVehicleChoice = InputHandler.GetValidatedNumber(1, maxVehicle, $"Invalid input, Choose a number between 1 and {maxVehicle}:");
                    Vehicle?[] filteredByVehicle = garage.FilterVehicleType(userVehicleChoice);
                    DisplayVehicles(filteredByVehicle);
                    break;
                case 2:
                //filter doors
                case 3:
                    //filter wheels
                default:
                    break;
            }
        }
    }
}
