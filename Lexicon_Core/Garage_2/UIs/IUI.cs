using Lexicon2026.Garage_2.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lexicon2026.Garage_2.UIs
{
    internal interface IUI
    {
        int UIGarageStart();
        int GarageSize();
        int UIGarageUI();
        void ShowGarageFullMessage();
        int UserVehicleSelection();
        (string reg, string color, int doors, int wheels) UserVehicleDataSelection(string vehicleType, Handler handler);
    }
}
