using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.LINQ_exercise
{
    public class Student
    {
        public int Id { get; set; }
        public string Namn { get; set; } = "";
        public int Alder { get; set; }
        public string Klass { get; set; } = "";
        public int Poang { get; set; }
        public override string ToString()
        {
            return $" Id = {Id}, Namn = {Namn}, Alder = {Alder}, Klass = {Klass}, Poang = {Poang}";
            ;
        }
    }
}