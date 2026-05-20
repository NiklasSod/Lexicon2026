using Lexicon2026.Garage_2.Handlers;
using Lexicon2026.Garage_2.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.UIs
{
    internal class UI : IUI
    {
        public int UIGarageStart()
        {
            Console.WriteLine("Do you want to build a garage or come to a half full one with 10 free spots left?");
            Console.WriteLine("1: I build it from scratch!");
            Console.WriteLine("2: Let me see the existing one.");
            int userChoice = InputHandler.GetValidatedNumber(1, 2, "Invalid input, Choose a number between 1 and 2:");
            Console.Clear();
            return userChoice;
        }

        public int GarageSize()
        {
            Console.WriteLine("How many parking spots do you need in the garage? \nChoose a number between 1 - 1000");
            return InputHandler.GetValidatedNumber(1, 1000, "Invalid input, Choose a number between 1 and 1000:");
        }

        public int UIGarageUI()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the garage, select what to do by pressing the corresponding number:\n");
            Console.WriteLine("1: Park a vehicle");
            Console.WriteLine("2: Take out a vehicle");
            Console.WriteLine("3: Look at all vehicles");
            Console.WriteLine("4: Look for a vehicle based on filter");
            Console.WriteLine("5: Exit program");
            return InputHandler.GetValidatedNumber(1, 5, "Invalid input, Choose a number between 1 and 5:");
        }

        public void ShowGarageFullMessage()
        {
            Console.Clear();
            Console.WriteLine("Garage is at full capacity \nPress anything to return to the main menu");
            Console.ReadKey();
        }

        public int UserVehicleSelection()
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
            return vehicleChoice;
        }

        public (string reg, string color, int doors, int wheels) UserVehicleDataSelection(string vehicleType, Handler handler)
        {
            Console.Clear();
            Console.WriteLine($"Great choice, some questions around your {vehicleType.ToLower()}:");

            Console.WriteLine("What is the registration number?");
            int minReg = 6;
            int maxReg = 30;
            string registrationNumber = InputHandler.GetValidatedString(
                handler,
                minReg,
                maxReg,
                $"Invalid registration number, at least {minReg} characters (max {maxReg}), try again",
                true);

            Console.WriteLine($"What color does the {vehicleType.ToLower()} have?");
            int minColor = 2;
            int maxColor = 24;
            string color = InputHandler.GetValidatedString(
                handler,
                minColor,
                maxColor,
                $"Invalid color, at least {minColor} characters (max {maxColor}), try again");

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

            return (registrationNumber, color, doors, wheels);
        }

        public int FinishBuildCarUI()
        {
            Console.WriteLine("How many horsepowers does the car have?");
            while (true)
            {
                string? inputHorsePower = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputHorsePower) || !int.TryParse(inputHorsePower, out int horsePower))
                {
                    Console.WriteLine("Try again:");
                    continue;
                }
                return horsePower;
            }
        }

        public int FinishBuildAirplaneUI()
        {
            Console.WriteLine("What is the max speed of this airplane in kilometers?");
            while (true)
            {
                string? inputMaxSpeed = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputMaxSpeed) || !int.TryParse(inputMaxSpeed, out int maxSpeed))
                {
                    Console.WriteLine("Try again:");
                    continue;
                }
                return maxSpeed;
            }
        }

        public bool FinishBuildBicycleUI()
        {
            Console.WriteLine("Does your bicycle have a package holder?");
            Console.WriteLine("Input 1 for yes - 2 for no");
            while (true)
            {
                string? inputPackageHolder = Console.ReadLine();
                if (inputPackageHolder == "1")
                {
                    return true;
                }
                if (inputPackageHolder == "2")
                {
                    return false;
                }
                Console.WriteLine("Try again:");
            }
        }

        public int FinishBuildMotorcycleUI()
        {
            Console.WriteLine("What is the cylinder volume of this motorcycle?");
            while (true)
            {
                string? inputCylinderVolume = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputCylinderVolume) || !int.TryParse(inputCylinderVolume, out int cylinderVolume))
                {
                    Console.WriteLine("Try again:");
                    continue;
                }
                return cylinderVolume;
            }
        }

        public int FinishBuildBusUI()
        {
            Console.WriteLine("How many passangers can sit in this bus?");
            while (true)
            {
                string? inputSeats = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputSeats) || !int.TryParse(inputSeats, out int seats))
                {
                    Console.WriteLine("Try again:");
                    continue;
                }
                return seats;
            }
        }

        public double FinishBuildBoatUI()
        {
            Console.WriteLine("How long is this boat in meters? \nEx: 4.20 for 4 meters and 20 centimeters");
            while (true)
            {
                string? inputLengt = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputLengt) || !double.TryParse(inputLengt, System.Globalization.CultureInfo.InvariantCulture, out double length))
                {
                    Console.WriteLine("Try again:");
                    continue;
                }
                return length;
            }
        }

        public void RemoveVehicleByRegistration(Handler handler)
        {
            Console.Clear();
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
                    UIGarageUI();
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
    }
}
