namespace GarageLogic.Vehicles.Types
{
    public abstract class ElectricalVehicle : Vehicle
    {
        public float RemainingBatteryTime { get; set; }
        public float MaxBatteryTime { get; set; }

        public void ChargeBattery(float i_HoursToAdd)
        {

        }
    }
}