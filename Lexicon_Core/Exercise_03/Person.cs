using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_03
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
            _salary *= (1 + percentage / 100);
        }
    }
}
