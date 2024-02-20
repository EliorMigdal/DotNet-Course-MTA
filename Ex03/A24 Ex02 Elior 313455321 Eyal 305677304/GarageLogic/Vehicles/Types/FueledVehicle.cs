namespace GarageLogic.Vehicles.Types
{
    internal abstract class FueledVehicle : Vehicle
    {
        public eFuelType FuelType { get; set; }
        public float RemainingFuel { get; set; }
        public float MaxFuelCapacity { get; set; }

        public void AddFuel(float i_Fuel)
        {

        }
    }
}