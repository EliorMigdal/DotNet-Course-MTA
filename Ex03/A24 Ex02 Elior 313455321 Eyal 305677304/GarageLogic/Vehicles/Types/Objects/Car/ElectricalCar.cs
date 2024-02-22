namespace GarageLogic.Vehicles.Types.Objects.Car
{
    public class ElectricalCar : ElectricalVehicle
    {
        public CarInfo CarInfo { get; set; }

        public ElectricalCar()
        {
            InstallWheels((int)eNumOfWheels.Car, (float)eMaxWheelAirPressure.Car);
            MaxBatteryTime = 2.8f;
        }
    }
}