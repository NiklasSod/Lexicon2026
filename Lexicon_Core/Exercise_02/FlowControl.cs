using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_02
{
    internal class FlowControl
    {
        public static void Main()
        {
            while (true)
            {
                int userChoice = UserMenu();

                switch (userChoice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect input, press enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static int UserMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the main menu");
            Console.WriteLine("- Cinema Paradiso -");
            Console.WriteLine("Press:");
            Console.WriteLine("Enter 0 - to exit");
            string? input = Console.ReadLine();

            return UserInput(input);
        }

        public static int UserInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return -1;
            if (!int.TryParse(input, out int userChoice)) return -1;
            return userChoice;
        }
    }
}
