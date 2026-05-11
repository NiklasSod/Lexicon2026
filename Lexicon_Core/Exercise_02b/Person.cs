using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_02b
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private decimal _salary;

        public string FirstName => _firstName;
        public int Age => _age;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            List<string> errorMessages = new List<string> { };
            if (firstName.Length < 3) { 
                errorMessages.Add("First name cannot contain fewer than 3 symbols! ");
            }
            if (lastName.Length < 3)
            {
                errorMessages.Add("Last name cannot contain fewer than 3 symbols! ");
            }
            if (age <= 0)
            {
                errorMessages.Add("Age cannot be zero or negative integer! ");
            }
            if (salary < 460.0m)
            {
                errorMessages.Add("Salary can't be less than 460 dollar!");
            }
            if (errorMessages.Count > 0) throw new ArgumentException(string.Join("", errorMessages));

            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _salary = salary;
        }

        // test 1
        //public override string ToString()
        //{
        //    return $"{_firstName} {_lastName} is {_age} years old.";
        //}

        // test 2
        public override string ToString()
        {
            return $"{_firstName} {_lastName} receives {_salary} dollars.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                _salary *= (1 + (percentage / 2) / 100);
            } else
            {
                _salary *= (1 + percentage / 100);
            }
        }
    }
}
