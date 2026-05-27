using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_5
{
    internal class Program
    {
        public static void Main()
        {
            Publisher pub = new Publisher();
            Subscriber sub = new Subscriber();

            pub.CustomEvent += sub.OnCustomEventReceived;
            pub.DoSomethingAndTrigger(true);
        }
    }
}
