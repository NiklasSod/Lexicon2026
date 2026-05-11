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
        public void ParkVehicle(Vehicle vehicle) {
            // add a vehicle
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
