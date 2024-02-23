using System.Text;

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

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.Append(CarInfo.ToString());

            return stringBuilder.ToString();
        }
    }
}