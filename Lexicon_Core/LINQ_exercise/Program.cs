using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Exercise_03.VehicleTypes;
using Lexicon2026.LINQ_exercise;

namespace Lexicon2026.LINQ_exercise
{
    class Program
    {
        public static void Main()
        {
            List<Student> studenter = new List<Student>
                {
                new Student { Id = 1, Namn = "Anna", Alder = 19, Klass = "A", Poang = 85 },
                new Student { Id = 2, Namn = "Bertil", Alder = 22, Klass = "B", Poang = 72 },
                new Student { Id = 3, Namn = "Cecilia", Alder = 20, Klass = "A", Poang = 91 },
                new Student { Id = 4, Namn = "David", Alder = 24, Klass = "C", Poang = 64 },
                new Student { Id = 5, Namn = "Eva", Alder = 19, Klass = "B", Poang = 85 },
                new Student { Id = 6, Namn = "Felix", Alder = 21, Klass = "A", Poang = 77 },
                new Student { Id = 7, Namn = "Gustav", Alder = 23, Klass = "C", Poang = 58 },
                new Student { Id = 8, Namn = "Hanna", Alder = 20, Klass = "B", Poang = 95 }
                };
            Console.WriteLine("LINQ-ÖVNINGAR MED STUDENTER\n");

            // Where
            var studentUnder20 = studenter.Where(p => p.Alder < 20);
            Console.WriteLine("Students under the age of 20:");
            foreach ( var student in studentUnder20)
            {
                Console.WriteLine(student.ToString());
            }
            var studentScoreOver80 = studenter.Where(p => p.Poang > 80);
            Console.WriteLine("\nStudents with score above 80:");
            foreach ( var student in studentScoreOver80)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}
