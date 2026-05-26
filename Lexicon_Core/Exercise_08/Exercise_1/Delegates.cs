using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_08.Exercise_1
{
    //// test
    //delegate int CalcSum(int x, int y);
    //internal class Delegates
    //{
    //    public static int Add(int x, int y)
    //    {
    //        return x + y;
    //    }

    //    public static int Remove(int x, int y)
    //    {
    //        return x - y;
    //    }
    //}
    public delegate int CalcSum (int x);
    class Delegates
    {
        public static void Main()
        {
            var del1 = new CalcSum(MultiplyNumber);
            var del2 = new CalcSum(RemoveFive);
            var del3 = new CalcSum(AddFive);
            var del4 = new CalcSum(DoubleNumber);

            del1 += del2 += del3 += del4;
            del1(10);
            Console.ReadLine();
        }

        static int MultiplyNumber(int x)
        {
            int answer = x * x;
            Console.WriteLine($"Your number {x} times itself is: {answer}");
            return answer;
        }
        static int RemoveFive(int x)
        {
            int answer = x - 5;
            Console.WriteLine($"Your number {x} minus five is: {answer}");
            return answer;
        }
        static int AddFive(int x)
        {
            int answer = x + 5;
            Console.WriteLine($"Your number {x} plus five is: {answer}");
            return answer;
        }
        static int DoubleNumber(int x)
        {
            int answer = x * 2;
            Console.WriteLine($"Your number {x} times two is: {answer}");
            return answer;
        }
    }
}
