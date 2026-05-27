using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_3
{
    internal class Subscriber
    {
        public void OnProcessCompleted(object source, EventArgs args)
        {
            Console.WriteLine("Subscriber körs!");
        }
    }
}
