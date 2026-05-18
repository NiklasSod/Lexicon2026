using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.VehicleTypes
{
    internal class Airplane : Vehicle, IVehicle
    {
        public int MaxSpeed { get; set; }

        public override string ToString()
        {
            string airplaneInfo = base.ToString() + $" with a max speed of {MaxSpeed}.";

            return airplaneInfo;
        }
    }
}
