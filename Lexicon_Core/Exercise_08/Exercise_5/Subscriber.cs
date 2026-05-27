using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_5
{
    internal class Subscriber
    {
        public void OnCustomEventReceived(object? sender, CustomMessageEventArgs e)
        {
            Console.WriteLine("\n Subscriber tog emot ett Event! ");
            Console.WriteLine($"Meddelande: {e.CustomMessage}");
        }
    }
}
