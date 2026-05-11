using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Exercise_03
{
    // an airplane takes up as much space (a spot) as a car
    internal class Garage
    {
        private readonly Vehicle[] vehicles;

        public Garage(int capacity)
        {
            vehicles = new Vehicle[capacity];
        }

        // method to add vehicle + feedback to user
        public void ParkVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    Console.WriteLine($"\nParked: {vehicle.GetType().Name}");
                    Console.WriteLine("Press any button");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Garage is full. Cannot park vehicle.");
        }

        // method to view all vehicle

        // method to view vehicle type and amount

        // method to remove vehicle + feedback to user

        // method search registration nr 
        // check user input .ToLower

        // method? lookup on vehicles with one or more filters, ex: all black vehicles with four tires

        // user can close the program in a good way
    }
}
