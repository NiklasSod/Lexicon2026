using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.VehicleTypes
{
    internal class Motorcycle : Vehicle, IVehicle
    {
        public int CylinderVolume { get; set; }

        public override string ToString()
        {
            string baseInfo = base.ToString();

            if (CylinderVolume != 0)
            {
                baseInfo += $" and with a cylinder volume of {CylinderVolume}.";
            }

            return baseInfo;
        }
    }
}
