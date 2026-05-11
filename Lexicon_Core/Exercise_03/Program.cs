using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Lexicon2026.Exercise_03
{
    public class Program
    {
        public static void Main()
        {
            GarageSize();
            GarageUI();
        }

        private static void GarageSize()
        {
            int garageSize;
            Console.WriteLine("How many parking spots do you need in the garage? \nChoose a number between 1 - 1000");
            while (true)
            {
                string? number = Console.ReadLine();
                if (!int.TryParse(number, out garageSize))
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
            Garage garage = new Garage(garageSize);
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
                if (!int.TryParse(number, out userInput))
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
                    //string[] vehicleData = UserVehicleData();
                    //Garage.ParkVehicle();
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
            // more types
            int userInput;
            while (true)
            {
                string? number = Console.ReadLine();
                if (!int.TryParse(number, out userInput))
                {
                    Console.WriteLine("Invalid number, Choose a number between 1 and X:"); // X
                    continue;
                }
                if (userInput < 1 || userInput > 3) // update 3 
                {
                    Console.WriteLine("Choose a number between 1 and X:"); // X
                    continue;
                }
                if (userInput == 1) return "Car";
                if (userInput == 2) return "Airplane";
                if (userInput == 3) return "Bicycle";
                // more types return
            }
        }
    }
}
