namespace GarageLogic.Vehicles.Types.Objects.Car
{
    public class ElectricalCar : ElectricalVehicle
    {
        public ElectricalCar()
        {
            InstallWheels((int)eNumOfWheels.Car, (float)eMaxWheelAirPressure.Car);
            InitializeMaxBatteryTime(4.8f);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}