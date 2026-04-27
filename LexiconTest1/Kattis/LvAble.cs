using System;
using System.Collections.Generic;
using System.Text;

// https://open.kattis.com/problems/lvable

namespace LexiconTest1.Kattis
{
    internal class LvAble
    {
        static void Main(string[] args)
        {
            int stringLength = int.Parse(Console.ReadLine());
            string value = Console.ReadLine();

            int answer = MakeLV(stringLength, value);
            Console.WriteLine(answer);
            Console.ReadLine();
        }

        static int MakeLV(int stringLength, string stringValue)
        {
            int index = stringValue.IndexOf("lv");
            if (index != -1) return 0;

            int index2 = stringValue.IndexOf("vl");
            if (index2 != -1)
            {
                // swap
                return 1;
            }

            int index3 = stringValue.IndexOf("l");
            if (index3 == stringLength)
            {
                // stringValue = stringValue + "v";
                return 1;
            }
            if (index3 != -1)
            {
                // stringValue.Insert(index3 + 1, "v");
                return 1;
            }

            int index4 = stringValue.IndexOf("v");
            if (index4 == 0)
            {
                // stringValue = "l" + stringValue;
                return 1;
            }
            if (index4 != -1)
            {
                // stringValue.Insert(index3 - 1, "l");
                return 1;
            }

            return 2;
        }
    }
}
