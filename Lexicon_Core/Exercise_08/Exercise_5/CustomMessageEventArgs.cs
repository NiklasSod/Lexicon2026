using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_5
{
    internal class CustomMessageEventArgs(string message) : EventArgs
    {
        public string CustomMessage { get; } = message;
    }
}
