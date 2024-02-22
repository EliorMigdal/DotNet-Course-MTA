namespace GarageLogic.Vehicles.Types.Objects.Car
{
    public class FueledCar : FueledVehicle
    {
        public CarInfo CarInfo { get; set; }

        public FueledCar()
        {
            InstallWheels((int)eNumOfWheels.Car, (float)eMaxWheelAirPressure.Car);
            FuelType = eFuelType.Octan95;
            MaxFuelCapacity = 58f;
        }
    }
}