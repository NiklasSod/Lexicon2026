using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Lexicon2026.Exercise_02b
{
    internal class Encapsulation
    {
        // test 1
        //public static void Main()
        //{
        //    var lines = 5;
        //    var persons = new List<Person>();
        //    for (int i = 0; i < lines; i++)
        //    {
        //        var cmdArgs = Console.ReadLine().Split();
        //        var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
        //        persons.Add(person);
        //    }
        //    persons.OrderBy(p => p.FirstName)
        //    .ThenBy(p => p.Age)
        //    .ToList()
        //    .ForEach(p => Console.WriteLine(p.ToString()));
        //    Console.ReadLine();
        //}

        // test 2
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();
                    var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                    int.Parse(cmdArgs[2]),
                    decimal.Parse(cmdArgs[3], CultureInfo.InvariantCulture));
                    persons.Add(person);
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            var bonus = decimal.Parse(Console.ReadLine());
            persons.ForEach(p => p.IncreaseSalary(bonus));
            persons.ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}
