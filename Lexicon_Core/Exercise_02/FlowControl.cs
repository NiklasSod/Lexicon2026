using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Lexicon2026.Exercise_02
{
    internal class FlowControl
    {
        public class Person
        {
            public string? Name { get; set; }
            public int Age { get; set; }
        }

        private static List<Person> bookingList = new List<Person>();

        public static void Main()
        {

            while (true)
            {
                int userChoice = MainMenu();

                switch (userChoice)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        BookingMenu();
                        break;
                    case 2:
                        BookingManyMenu();
                        break;
                    case 3:
                        ViewList();
                        break;
                    case 4:
                        RepeatTheUser();
                        break;
                    case 5:
                        TheThirdWord();
                        break;
                    default:
                        ErrorMessage("Incorrect input, press enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static int MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the main menu");
            Console.WriteLine("- Cinema Paradiso -");
            Console.WriteLine("Press:");
            Console.WriteLine("Enter 0 - to exit");
            Console.WriteLine("Enter 1 - Book a ticket");
            Console.WriteLine("Enter 2 - Book many tickets");
            Console.WriteLine("Enter 3 - Check your booking");
            Console.WriteLine("---");
            Console.WriteLine("Enter 4 - Repeat");
            Console.WriteLine("Enter 5 - The third word");
            string? input = Console.ReadLine();

            return UserInput(input);
        }

        private static void BookingMenu()
        {
            Person newPerson = new Person();
            Console.WriteLine("\nPlease provide your age:");
            while (true)
            {
                string? age = Console.ReadLine();
                int result = UserInput(age);
                if (result < 0)
                {
                    ErrorMessage("Something went wrong");
                    Console.WriteLine("Please provide your age:");
                }
                else
                {
                    Console.WriteLine($"\nAge {result} accepted.");
                    newPerson.Age = result;
                    break;
                }
            }
            Console.WriteLine("\nPlease provide your full name:");
            string? name = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty, enter name again:");
                name = Console.ReadLine();
            }
            newPerson.Name = name;
            Console.WriteLine($"\nA {TicketType(newPerson.Age)} will be booked for {newPerson.Name}, is this ok?");
            Console.WriteLine("Press 0 to Exit or 1 to approve");
            int userChoice = UserInput(Console.ReadLine());
            if (userChoice == 0)
            {
                Console.WriteLine("\nCancelling... Press any key to return to the main menu");
                Console.ReadKey(true);
                return;
            }
            Console.WriteLine($"\nA {TicketType(newPerson.Age)} is now booked for {newPerson.Name}");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey(true);
            bookingList.Add(newPerson);
        }

        private static void BookingManyMenu()
        {
            Console.WriteLine("How many people do you want to book (between 2 and 10)?");
            int userChoice = UserInput(Console.ReadLine());
            if (userChoice < 2 || userChoice > 10)
            {
                Console.WriteLine("\nCancelling... incorrect input. Press any key to return to the main menu");
                Console.ReadKey(true);
                return;
            }
            for (int i = 0; i < userChoice; i++)
            {
                BookingMenu();
            }
        }

        private static void ViewList()
        {
            if (bookingList.Count == 0)
            {
                Console.WriteLine("\nList is empty");
                Console.WriteLine("Press anything to return to the main menu");
                Console.ReadKey(true);
            } else
            {
                int totalPrice = 0;
                foreach (Person person in bookingList) {
                    var ticket = TicketType(person.Age);
                    totalPrice += TotalPrice(person.Age);
                    Console.WriteLine($"\nName: {person.Name}\nAge: {person.Age.ToString()}\nPrice: {char.ToUpper(ticket[0]) + ticket.Substring(1)}");
                }
                Console.WriteLine($"\nTotal price: {totalPrice}");
                Console.WriteLine("Press anything to return to the main menu");
                Console.ReadKey(true);
            }
        }

        private static void ErrorMessage(string? text = null)
        {
            Console.WriteLine(text);
        }

        public static int TotalPrice(int age)
        {
            if (age < 5) return 0;
            if (age < 20) return 80;
            if (age > 100) return 0;
            if (age > 64) return 90;
            return 120;
        }

        private static string TicketType(int age)
        {
            if (age < 5) return "free ticket - 0 sek";
            if (age < 20) return "youth ticket - 80 sek";
            if (age > 100) return "free ticket - 0 sek";
            if (age > 64) return "pensioner ticket - 90 sek";
            return "standard ticket - 120 sek";
        }

        public static int UserInput(string? input)
        {
            if (string.IsNullOrWhiteSpace(input)) return -1;
            if (!int.TryParse(input, out int userChoice)) return -1;
            return userChoice;
        }

        private static void RepeatTheUser()
        {
            Console.WriteLine("\nWrite something, anything!");
            string? anything = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(anything))
            {
                Console.WriteLine("You cannot write nothing, try again");
                anything = Console.ReadLine();
            }
            for (int i = 0; i < 10; i++) {
                Console.Write($"{anything} ");
            }
            Console.WriteLine("\nVery cool - Press any key to return to main window");
            Console.ReadKey(true);
        }

        private static void TheThirdWord()
        {
            Console.WriteLine("\nWrite a sentence, at least three words long");
            var sentence = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(sentence))
            {
                Console.WriteLine("Try again");
                sentence = Console.ReadLine();
            }
            if (sentence.Split(" ").Length < 3)
            {
                Console.WriteLine("\nError - returning you to the main menu");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                return;
            }
            string thirdWord = sentence.Split(" ")[2];
            Console.WriteLine($"\nNice,thanks! The third word in that sentence was: {thirdWord}");
            Console.WriteLine("Press any key to continue to main menu");
            Console.ReadKey(true);
        }
    }
}
