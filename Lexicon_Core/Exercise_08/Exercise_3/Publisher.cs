using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_3
{
    class Publisher
    {
        public delegate void NotifyEventHandler(object s, EventArgs e);

        public event NotifyEventHandler? ProcessCompleted;

        public static void Main()
        {
            //
        }

        public void StartProcess(bool shouldTriggerEvent)
        {
            Console.WriteLine("Processen startar...");
            System.Threading.Thread.Sleep(1000);

            if (shouldTriggerEvent)
            {
                OnProcessCompleted();
            }
            else
            {
                Console.WriteLine("Processen avslutades, men villkoret uppfylldes inte. Inget event triggas.");
            }
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
