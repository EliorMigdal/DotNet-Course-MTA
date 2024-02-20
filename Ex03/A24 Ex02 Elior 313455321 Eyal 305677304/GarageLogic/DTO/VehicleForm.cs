using GarageLogic.Vehicles;

namespace GarageLogic.DTO
{
    internal abstract class VehicleForm
    {
        public VehicleInfo VehicleInfo { get; set; }
        public WheelForm WheelForm { get; set; }
    }
}