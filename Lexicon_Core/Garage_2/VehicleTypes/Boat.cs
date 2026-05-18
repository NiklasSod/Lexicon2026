using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.VehicleTypes
{
    internal class Boat : Vehicle, IVehicle
    {
        public double Length { get; set; }

        public override string ToString()
        {
            string boatInfo = base.ToString();
            if (Length != 0)
            {
                boatInfo += $" this boat has length {Length}m.";
            }

            return boatInfo;
        }
    }
}
