using System.Collections.Generic;

namespace GarageLogic.Vehicles
{
    internal abstract class Vehicle
    {
        public VehicleInfo VehicleInfo { get; set; }
        public List<Wheel> Wheels { get; set; } = new List<Wheel>();
    }
}