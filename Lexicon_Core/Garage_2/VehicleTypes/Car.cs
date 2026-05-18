using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.VehicleTypes
{
    internal class Car : Vehicle, IVehicle
    {
        public int HorsePower { get; set; }

        public override string ToString()
        {
            string carInfo = base.ToString();

            if (HorsePower != 0)
            {
                carInfo += $" and with {HorsePower} horsepower.";
            }

            return carInfo;
        }
    }
}
