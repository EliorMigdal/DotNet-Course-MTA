using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.Truck
{
    public class Truck : FueledVehicle
    {
        public TruckInfo TruckInfo { get; set; }

        public Truck()
        {
            InstallWheels((int)eNumOfWheels.Truck, (float)eMaxWheelAirPressure.Truck);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.Append(TruckInfo.ToString());

            return stringBuilder.ToString();
        }
    }
}