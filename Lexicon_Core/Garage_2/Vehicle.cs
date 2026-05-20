using Lexicon2026.Garage_2.VehicleTypes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Lexicon2026.Garage_2;

public abstract class Vehicle : IVehicle
{
    public required string RegistrationNumber { get; set; }
    public required string Color { get; set; }
    public int Wheels { get; set; }
    public int Doors { get; set; }

    public override string ToString()
    {
        string icon = GetType().Name switch
        {
            "Airplane" => "✈️",
            "Bicycle" => "🚲",
            "Boat" => "🚤",
            "Bus" => "🚌",
            "Car" => "🚗",
            "Motorcycle" => "🏍️",
            _ => "🚜"
        };

        string vehicleInfo = $"{icon} {GetType().Name}\nReg no: {RegistrationNumber.ToUpper()} of {Color.ToLower()} color";
        if (Doors != 0)
        {
            vehicleInfo += $" having {Doors} doors";
        }
        if (Wheels != 0)
        {
            vehicleInfo += $" with {Wheels} wheels";
        }
        return vehicleInfo;
    }
}
