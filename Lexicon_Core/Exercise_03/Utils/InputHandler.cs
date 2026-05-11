using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_03.Utils
{
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
    }
}
