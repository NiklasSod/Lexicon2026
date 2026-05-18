using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Lexicon2026.Garage_2.VehicleTypes
{
    internal class Bus : Vehicle, IVehicle
    {
        public int Seats { get; set; }

        public override string ToString()
        {
            string busInfo = base.ToString();
            if (Seats != 0)
            {
                busInfo += $" this bus has {Seats} seats.";
            }

            return busInfo;
        }
    }
}
