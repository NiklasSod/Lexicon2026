using System;
using System.Collections.Generic;
using System.Text;
using BethanysPieShopHRM.Utilities;

namespace BethanysPieShopHRM
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Bethany's Pie Shop");

            MyFunctions.SayHello("Niklas");

            Console.ReadLine();
        }
    }
}
