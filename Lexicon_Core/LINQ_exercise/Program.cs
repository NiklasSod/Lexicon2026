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

            //// Where
            //var studentUnder20 = studenter.Where(p => p.Alder < 20);
            //Console.WriteLine("Students under the age of 20:");
            //foreach ( var student in studentUnder20)
            //{
            //    Console.WriteLine(student.ToString());
            //}

            //var studentScoreOver80 = studenter.Where(p => p.Poang > 80);
            //Console.WriteLine("\nStudents with score above 80:");
            //foreach ( var student in studentScoreOver80)
            //{
            //    Console.WriteLine(student.ToString());
            //}

            //// Select
            //var studentName = studenter.Select(p => p.Namn);
            //Console.WriteLine("Student names:");
            //foreach (var student in studentName)
            //{
            //    Console.WriteLine(student);
            //}

            //var studentWithGrade = studenter.Select(p => new { p.Namn, p.Poang });
            //Console.WriteLine("\nStudents (names and grade):");
            //foreach (var student in studentWithGrade)
            //{
            //    Console.WriteLine($"{student.Namn}: {student.Poang}");
            //}

            //// OrderBy
            //var studentByAge = studenter.OrderBy(p => p.Alder);
            //Console.WriteLine("Students sorted by age:");
            //foreach (var student in studentByAge)
            //{
            //    Console.WriteLine(student);
            //}

            //var studentsByHighestGrade = studenter.OrderByDescending(p => p.Poang);
            //Console.WriteLine("\nStudents sorted by grade:");
            //foreach (var student in studentsByHighestGrade)
            //{
            //    Console.WriteLine(student);
            //}

            //// OrderBy
            //var studentByAge = studenter.OrderBy(p => p.Alder);
            //Console.WriteLine("Students sorted by age:");
            //foreach (var student in studentByAge)
            //{
            //    Console.WriteLine(student);
            //}

            //var studentsByHighestGrade = studenter.OrderByDescending(p => p.Poang);
            //Console.WriteLine("\nStudents sorted by grade:");
            //foreach (var student in studentsByHighestGrade)
            //{
            //    Console.WriteLine(student);
            //}

            //// Count
            //var studentAmount = studenter.Count();
            //Console.WriteLine("Amount of students:");
            //Console.WriteLine(studentAmount);

            //var studentsInClassA = studenter.Count(p => p.Klass == "A");
            //Console.WriteLine("\nAmount of students in class A:");
            //Console.WriteLine(studentsInClassA);

            //// Take
            //var threeStudents = studenter.Take(3);
            //Console.WriteLine("Three students:");
            //foreach (Student student in threeStudents)
            //{
            //    Console.WriteLine(student);
            //}

            //var bestStudentsByOrder = studenter.OrderByDescending(student => student.Poang);
            //var bestTwoStudents = bestStudentsByOrder.Take(2);
            //Console.WriteLine("\nThe two best students:");
            //foreach (Student student in bestTwoStudents)
            //{
            //    Console.WriteLine(student);
            //}

            //// Distinct
            //var classNames = studenter.Select(p => p.Namn);
            //var uniqueNames = classNames.Distinct();
            //Console.WriteLine("Student (unique) names:");
            //foreach (string name in uniqueNames)
            //{
            //    Console.WriteLine(name);
            //}

            //var classAges = studenter.Select(p => p.Alder);
            //var uniqueAges = classAges.Distinct();
            //Console.WriteLine("\nStudent (unique) names:");
            //foreach (int age in uniqueAges)
            //{
            //    Console.WriteLine(age);
            //}

            //// Any / All
            //var studentWithFullScore = studenter.Any(p => p.Poang == 100);
            //Console.WriteLine("Did any student get 100 points?");
            //Console.WriteLine(studentWithFullScore ? "Yes" : "No");

            //var studentsAbove50Points = studenter.All(p => p.Poang > 50);
            //Console.WriteLine("\nDid all student get above 50 points?");
            //Console.WriteLine(studentsAbove50Points ? "Yes" : "No");

            // FirstOrDefault / Last / Single
            var firstStudentClassB = studenter.FirstOrDefault(p => p.Klass == "B");
            Console.WriteLine("First student in class B:");
            Console.WriteLine(firstStudentClassB);

            var lastStudent = studenter.Last();
            Console.WriteLine("\nLast student in list:");
            Console.WriteLine(lastStudent);

            int id = 5;
            var studentWithId = studenter.Single(p => p.Id == id);
            Console.WriteLine($"\nStudent with id {id}:");
            Console.WriteLine(studentWithId);

            // GroupBy


            // Sum / Average / Min / Max

        }
    }
}
