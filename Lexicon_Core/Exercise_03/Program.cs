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
                    // do stuff
                    break;
                case 3:
                    // do stuff
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
            // add more types?
            while (true)
            {
                string? number = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(number) || !int.TryParse(number, out int userInput))
                {
                    Console.WriteLine("Invalid number, Choose a number between 1 and 3:"); // X = 3 for now
                    continue;
                }
                if (userInput < 1 || userInput > 3) // update 3 if adding more
                {
                    Console.WriteLine("Choose a number between 1 and 3:"); // X = 3 for now
                    continue;
                }
                if (userInput == 1) return "Car";
                if (userInput == 2) return "Airplane";
                if (userInput == 3) return "Bicycle";
            }
        }

        private static Vehicle UserVehicleData(string vehicleType)
        {
            if (vehicleType == "Car")
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
                    break;
                }

                string color;
                Console.WriteLine("What color does the car have?");
                while (true)
                {
                    string? input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Invalid color, try again");
                        continue;
                    }
                    color = input;
                    break;
                }

                Car car = new()
                {
                    RegistrationNumber = registrationNumber,
                    Color = color,
                    Wheels = 4
                };
                return car;
            }

            // If other vehicle types are added later, handle them here.
            throw new NotSupportedException($"Vehicle type '{vehicleType}' is not supported.");
        }
    }
}
