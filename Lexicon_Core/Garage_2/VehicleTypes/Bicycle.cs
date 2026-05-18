using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.VehicleTypes
{
    internal class Bicycle : Vehicle, IVehicle
    {
        public bool PackageHolder { get; set; }

        public override string ToString()
        {
            string bicycleInfo = base.ToString();

            if (PackageHolder == true)
            {
                bicycleInfo += $" also equipped with an packageholder.";
            }

            return bicycleInfo;
        }
    }
}
