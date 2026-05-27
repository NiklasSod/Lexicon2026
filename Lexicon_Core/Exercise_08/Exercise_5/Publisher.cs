using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_5
{
    internal class Publisher
    {
        public event EventHandler<CustomMessageEventArgs>? CustomEvent;

        public void DoSomethingAndTrigger(bool trigger)
        {
            Console.WriteLine("Publisher: Arbetar på något...");
            System.Threading.Thread.Sleep(1000);
            if (trigger)
            {
                string msg = $"Larm! Eventet triggades klockan {DateTime.Now:T}.";
                OnCustomEvent(new CustomMessageEventArgs(msg));
            }
        }

        protected virtual void OnCustomEvent(CustomMessageEventArgs e)
        {
            CustomEvent?.Invoke(this, e);
        }
    }
}
