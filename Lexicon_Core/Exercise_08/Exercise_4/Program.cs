using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_4
{
    internal class Program
    {
        public delegate void MessageDel(string message);

        public static void Main()
        {

        }

        public static void DelOne(string message)
        {
            Console.WriteLine($"One + {message}");
        }

        public static void DelTwo(string message)
        {
            Console.WriteLine($"Two + {message}");
        }
    }
}
