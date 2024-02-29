namespace GarageLogic.Vehicles.Types.Objects.Car
{
    public class FueledCar : FueledVehicle
    {
        public FueledCar()
        {
            InstallWheels((int)eNumOfWheels.Car, (float)eMaxWheelAirPressure.Car);
            InitializeFuelData(eFuelType.Octan95, 58f);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}