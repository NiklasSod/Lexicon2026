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
            MessageDel myDel = DelOne;
            myDel += DelTwo;
            myDel("Test från Main!");

            // The Event and Delegate connection:
            // Delegaten är ritning och behållare. Inget Event utan att först ha en Delegate.
            // Här finns inget Event, med Event kan andra klasser endast välja att 
            // += prenumerera eller -= avprenumerera.
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
