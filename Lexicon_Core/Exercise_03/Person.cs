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

        public string FirstName => _firstName;
        public int Age => _age;

        public Person(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName} is {_age} years old.";
        }
    }
}
