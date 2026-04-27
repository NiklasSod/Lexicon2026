using System;
using System.Collections.Generic;
using System.Text;

// https://open.kattis.com/problems/fizzbuzz

namespace LexiconTest1.Kattis
{
    internal class FizzBuzz
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine(FizzBuzzSolver(i));
            }
            Console.ReadLine();
        }

        static string FizzBuzzSolver(int number)
        {
            if ((number % 3 == 0) && (number % 5 == 0)) return "FizzBuzz";
            else if (number % 3 == 0) return "Fizz";
            else if (number % 5 == 0) return "Buzz";
            else return number.ToString();
        }

        // Kattis solution

        //static void Main(string[] args)
        //{
        //    string inputLine = Console.ReadLine();
        //    string[] inputs = inputLine.Split(' ');
        //    int start = int.Parse(inputs[0]);
        //    int end = int.Parse(inputs[1]);
        //    int limit = int.Parse(inputs[2]);
        //    string[] solution = FizzBuzzSolver(start, end, limit);
        //    foreach (var item in solution)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadLine();
        //}

        //static string[] FizzBuzzSolver(int fizz, int buzz, int length)
        //{
        //    string[] solution = new string[length];

        //    for (int i = 1; i <= length; i++)
        //    {
        //        if ((i % fizz == 0) && (i % buzz == 0)) solution[i - 1] = "FizzBuzz";
        //        else if (i % fizz == 0) solution[i - 1] = "Fizz";
        //        else if (i % buzz == 0) solution[i - 1] = "Buzz";
        //        else solution[i - 1] = i.ToString();
        //    }
        //    return solution;
        //}
    }
}
