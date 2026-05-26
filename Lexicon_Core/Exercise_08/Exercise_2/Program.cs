using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_2
{
    public delegate string WriteBack(string name);

    class Program
    {
        public static void Main()
        {
            WriteBack myDelegate = Hello;
            myDelegate = Friendly;
            myDelegate = Goodbye;
            string result1 = myDelegate("Niklas");
            Console.WriteLine(result1);

            WriteBack multiDelegate = Hello;
            multiDelegate += Friendly;
            multiDelegate += Goodbye;
            string multiResult = multiDelegate("Niklas");
            Console.WriteLine(multiResult); // sista körs

            Console.ReadLine();
        }

        public static string Hello(string name) => $"Hi {name}.\n";
        public static string Friendly(string name) => $"Hope all is well, {name}\n";
        public static string Goodbye(string name) => $"Goodbye {name}!\n";
    }
}
