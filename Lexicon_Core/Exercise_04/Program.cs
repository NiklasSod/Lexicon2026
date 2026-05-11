using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Lexicon2026.Exercise_04
{
    public class Program
    {
        public static void Main()
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
    }
}
