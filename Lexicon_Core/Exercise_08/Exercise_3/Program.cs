using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_3
{
    public class Program
    {
        public static void Main()
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();

            // Connecting sub to event through delegate
            pub.ProcessCompleted += sub.OnProcessCompleted;

            Console.WriteLine("--- Startar ---");
            pub.StartProcess(true);

            Console.WriteLine();
            // pub.ProcessCompleted -= sub.OnProcessCompleted;
        }
    }
}
