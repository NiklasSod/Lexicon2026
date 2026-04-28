using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

/*
 * Vilka klasser bör ingå i programmet?
 * 
 * En känns rimligt, allt handlar om liknande sak.
 * 
 * 
 * Vilka attribut och metoder bör ingå i dessa klasser?
 * 
 * Tänker mig en Main och två hjälpklasser. Add / Read - edit: en till som kontrollerar user input.
 */

namespace Lexicon2026.Exercise_01
{
    internal class PersonalRegister
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to Restaurant Restaurontos personal register.");

            List<(string Name, int Salary)> employeeList = new List<(string, int)>();

            while (true) // console is not closed by user
            {
                Console.WriteLine("Press 1 to add a new person to the crew? ");
                Console.WriteLine("Press 2 to look up workers?");
                Console.WriteLine();

                int userChoice = UserInput(Console.ReadLine());

                switch(userChoice)
                {
                    case 1:
                        (string Name, int Salary) newEmployee = AddEmployee();
                        employeeList.Add(newEmployee);
                        break;
                    case 2:
                        if (employeeList.Count <= 0)
                        {
                            Console.WriteLine("No workers yet!");
                            break;
                        }
                        for (int i = 0; i < employeeList.Count; i++)
                        {
                            Console.WriteLine($"{employeeList[i].Name} - {employeeList[i].Salary}");
                        }
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter 1 or 2.");
                        break;
                }
            }
        }

        public static int UserInput(string? input)
        {
            if (input is null) return 0;
            if (!int.TryParse(input, out int userChoice)) return 0;
            return int.Parse(input);
        }

        public static (string Name, int Salary) AddEmployee()
        {
            Console.WriteLine("What is the name of the person?");
            string? inputName = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(inputName))
            {
                Console.WriteLine("Name cannot be empty, enter name again:");
                inputName = Console.ReadLine();
            }

            Console.WriteLine("What salary will they recieve?");
            string? inputSalary = Console.ReadLine();
            int salary = UserInput(inputSalary);
            while (salary <= 0)
            {
                Console.WriteLine("Incorrect, enter salary again:");
                salary = UserInput(Console.ReadLine());
            }
            ;
            Console.WriteLine("New employee added!");
            Console.WriteLine();

            return (inputName, salary);
        }
    }
}
