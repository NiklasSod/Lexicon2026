using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_02
{
    internal class TicketCalculator
    {
        public static int TotalPrice(int age)
        {
            if (age < 5) return 0;
            if (age < 20) return 80;
            if (age > 100) return 0;
            if (age > 64) return 90;
            return 120;
        }

        public static string TicketType(int age)
        {
            if (age < 5) return "free ticket - 0 sek";
            if (age < 20) return "youth ticket - 80 sek";
            if (age > 100) return "free ticket - 0 sek";
            if (age > 64) return "pensioner ticket - 90 sek";
            return "standard ticket - 120 sek";
        }
    }
}
