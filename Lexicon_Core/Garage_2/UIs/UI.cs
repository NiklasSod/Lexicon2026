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
    }
}
