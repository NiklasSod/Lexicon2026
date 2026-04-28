using System;
using System.Collections.Generic;
using System.Text;

/*
 * Vilka klasser bör ingå i programmet?
 * 
 * En känns rimligt, allt handlar om liknande sak.
 * 
 * 
 * Vilka attribut och metoder bör ingå i dessa klasser?
 * 
 * Tänker mig en Main och två hjälpklasser. Add / Read
 */

namespace Lexicon2026.Exercise_01
{
    internal class PersonalRegister
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Restaurant Restaurontos personal register.");
            while (true) // console is not closed
            {
                Console.WriteLine("Add a new person to the crew? Press 1");
                Console.WriteLine("Look up workers? Press 2");
                Console.ReadLine();
            }
        }
    }
}
