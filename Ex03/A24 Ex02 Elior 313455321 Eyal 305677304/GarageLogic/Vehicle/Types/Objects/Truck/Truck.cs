namespace GarageLogic.Vehicles.Types.Objects.Truck
{
    public class Truck : FueledVehicle
    {
        public Truck()
        {
            InstallWheels((int)eNumOfWheels.Truck, (float)eMaxWheelAirPressure.Truck);
            InitializeFuelData(eFuelType.Soler, 110f);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}