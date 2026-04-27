using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

/*
https://open.kattis.com/problems/busskortet
Initial idea:
Always check if 500 is enough, if not add 500 more
If 500 is too much at any time, do other stuff
*/

namespace LexiconTest1.Kattis
{
    internal class TheBusCard
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine(ChargingTimes(100));
            Console.WriteLine(ChargingTimes(250));
            Console.WriteLine(ChargingTimes(400));
            Console.WriteLine(ChargingTimes(500));
            Console.WriteLine(ChargingTimes(600));
            Console.WriteLine(ChargingTimes(650));
            Console.WriteLine(ChargingTimes(800));
            Console.WriteLine(ChargingTimes(1050));
            Console.WriteLine(ChargingTimes(1200));
            Console.WriteLine(ChargingTimes(2650));
            Console.ReadLine();
            */
        }

        // int[] sampleTestArray = new int[] { 100, 250, 400, 500, 600, 650, 800, 1050, 1200, 2650 };
        // int[] sampleAnswerArray = new int[] { 1, 2, 2, 1, 2, 2, 3, 3, 3, 6 };

        static int ChargingTimes(int amount)
        {
            int transactions = amount / 500;
            int rest = amount % 500;

            if (rest == 0)
            {
                return transactions;
            }

            if (rest > 400)
            {
                return transactions + 1;
            }

            int twoHundreds = rest / 200;
            int remainingAfterTwoHundred = rest % 200;

            if (remainingAfterTwoHundred > 100)
            {
                return transactions + twoHundreds + 1;
            }
            else if (remainingAfterTwoHundred == 0)
            {
                return transactions + twoHundreds;
            }
            else
            {
                return transactions + twoHundreds + 1;
            }
        }
    }
}
