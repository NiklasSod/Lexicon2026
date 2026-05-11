using Lexicon2026.Exercise_03.VehicleTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Lexicon2026.Exercise_03
{
    public class Program
    {
        private static Garage garage = null!;

        public static void Main()
        {
            int garageSize = GarageSize();
            garage = new Garage(garageSize);
            GarageUI();
        }

        private static int GarageSize()
        {
            int garageSize;
            Console.WriteLine("How many parking spots do you need in the garage? \nChoose a number between 1 - 1000");
            while (true)
            {
                string? number = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out garageSize))
                {
                    Console.WriteLine("Invalid number, Choose a number between 1 and 1000:");
                    continue;
                }
                if (garageSize < 1 || garageSize > 1000)
                {
                    Console.WriteLine("Choose a number between 1 and 1000:");
                    continue;
                }
                break;
            }
            return garageSize;
        }

        private static void GarageUI()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the garage, select what to do by pressing the corresponding number:\n");
            Console.WriteLine("1: Park a vehicle");
            Console.WriteLine("2: Take out a vehicle");
            Console.WriteLine("3: Lookup on a vehicle");
            int userInput;
            while (true)
            {
                string? number = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out userInput))
                {
                    Console.WriteLine("Invalid number, Choose a number between 1 and 3:");
                    continue;
                }
                if (userInput < 1 || userInput > 3)
                {
                    Console.WriteLine("Choose a number between 1 and 3:");
                    continue;
                }
                break;
            }
            switch (userInput)
            {
                case 1:
                    string vehicleType = UserVehicle();
                    Vehicle vehicle = UserVehicleData(vehicleType);
                    garage.ParkVehicle(vehicle);
                    GarageUI();
                    break;
                case 2:
                    getOneVehicle();
                    GarageUI();
                    break;
                case 3:
                    CheckVehicles();
                    GarageUI();
                    break;
                default:
                    // exit program
                    break;
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
            while (true)
            {
                string? number = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int userInput))
                {
                    Console.WriteLine($"Invalid number, Choose a number between 1 and {max}:");
                    continue;
                }
                if (userInput < 1 || userInput > max)
                {
                    Console.WriteLine($"Choose a number between 1 and {max}:");
                    continue;
                }
                if (userInput == 1) return "Car";
                if (userInput == 2) return "Airplane";
                if (userInput == 3) return "Bicycle";
                if (userInput == 4) return "Motorcycle";
                if (userInput == 5) return "Bus";
                if (userInput == 6) return "Boat";
            }
        }

        private static Vehicle UserVehicleData(string vehicleType)
        {
            string registrationNumber;
            Console.WriteLine("What is the registration number?");
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid registration number, at least 6 characters, try again");
                    continue;
                }
                registrationNumber = input;
                if (registrationNumber.Length < 6)
                {
                    Console.WriteLine("Invalid registration number, at least 6 characters, try again");
                    continue;
                }
                if (garage.CheckUniqueRegNo(registrationNumber))
                {
                    Console.WriteLine("Registration number already in garage!");
                    continue;
                }
                break;
            }

            string color;
            Console.WriteLine("What color does the vehicle have?");
            while (true)
            {
                string? inputColor = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputColor))
                {
                    Console.WriteLine("Invalid color, try again");
                    continue;
                }
                color = inputColor;
                break;
            }

            int doors;
            Console.WriteLine("Does the vehicle have doors, how many?");
            while (true)
            {
                string? inputDoors = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputDoors) || !int.TryParse(inputDoors, out doors))
                {
                    Console.WriteLine("Try again:");
                    continue;
                }
                break;
            }

            if (vehicleType == "Car")
            {
                return CarData(registrationNumber, color, doors);
            }

            if (vehicleType == "Airplane")
            {
                return AirplaneData(registrationNumber, color, doors);
            }

            if (vehicleType == "Bicycle")
            {
                return BicycleData(registrationNumber, color, doors);
            }

            if (vehicleType == "Motorcycle")
            {
                return MotorcycleData(registrationNumber, color, doors);
            }

            if (vehicleType == "Bus")
            {
                return BusData(registrationNumber, color, doors);
            }

            if (vehicleType == "Boat")
            {
                return BoatData(registrationNumber, color, doors);
            }

            throw new NotSupportedException($"Vehicle type '{vehicleType}' is not supported.");
        }

        private static Car CarData(string registrationNumber, string color, int doors) {
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
                Wheels = 4,
                Doors = doors,
                HorsePower = horsePower,
            };
            return car;
        }

        private static Airplane AirplaneData(string registrationNumber, string color, int doors)
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
                Wheels = 4,
                Doors = doors,
                MaxSpeed = maxSpeed,
            };
            return airplane;
        }

        private static Bicycle BicycleData(string registrationNumber, string color, int doors)
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
                Wheels = 4,
                Doors = doors,
                PackageHolder = packageHolder,
            };
            return bicycle;
        }

        private static Motorcycle MotorcycleData(string registrationNumber, string color, int doors)
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
                Wheels = 4,
                Doors = doors,
                CylinderVolume = cylinderVolume,
            };
            return motorcycle;
        }

        private static Bus BusData(string registrationNumber, string color, int doors)
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
                Wheels = 4,
                Doors = doors,
                Seats = seats,
            };
            return bus;
        }

        private static Boat BoatData(string registrationNumber, string color, int doors)
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
                Wheels = 4,
                Doors = doors,
                Length = length
            };
            return Boat;
        }

        private static void CheckVehicles()
        {
            Console.Clear();
            Vehicle?[] vehicles = garage.GetVehicles();
            bool empty = true;

            foreach (Vehicle? vehicle in vehicles)
            {
                if (vehicle != null)
                {
                    empty = false;
                    Console.WriteLine($"Type: {vehicle.GetType().Name}");
                    Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}");
                    Console.WriteLine($"Color: {vehicle.Color}");
                    Console.WriteLine($"Wheels: {vehicle.Wheels}");
                    Console.WriteLine($"Doors: {vehicle.Doors}");

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

        private static void getOneVehicle()
        {
            Console.Clear();
            Vehicle?[] vehicles = garage.GetVehicles();
            Console.WriteLine("Whats the registration number?");
            string? registrationNumber;
            while (true)
            {
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
                break;
            }
            bool removedVehicle = garage.TakeVehicles(registrationNumber);
            if (removedVehicle)
            {
                Console.WriteLine("Here is your vehicle! Press any key");
                Console.ReadKey();
            }
        }
    }
}
