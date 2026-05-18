using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2
{
    internal abstract class Vehicle
    {
        public required string RegistrationNumber { get; set; }
        public string? Color { get; set; }
        public int Wheels { get; set; }
        public int Doors { get; set; }
        //public int TankSize { get; set; }
        //public string? FuelType { get; set; }
        //public int Weight { get; set; }
    }
}
