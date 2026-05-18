using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Lexicon2026.Garage_2.Utils;

internal class InputHandler
{
    public static int GetValidatedNumber(int min, int max, string errorMessage)
    {
        while (true)
        {
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine(errorMessage);
                continue;
            }

            if (number < min || number > max)
            {
                Console.WriteLine($"Choose a number between {min} and {max}:");
                continue;
            }

            return number;
        }
    }

    public static string GetValidatedString(Garage garage, int min, int max, string error, bool checkUniqueRegNo = false)
    {
        string userInput;
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine(error);
                continue;
            }
            userInput = input;
            if (userInput.Length < min || userInput.Length > max)
            {
                Console.WriteLine(error);
                continue;
            }
            if (checkUniqueRegNo && garage.CheckUniqueRegNo(userInput))
            {
                Console.WriteLine("Registration number already in garage!");
                continue;
            }
            break;
        }
        return userInput;
    }
}
