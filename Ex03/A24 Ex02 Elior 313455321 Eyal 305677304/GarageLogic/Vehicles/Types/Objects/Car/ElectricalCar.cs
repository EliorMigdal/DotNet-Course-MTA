using System.Collections.Generic;
using System.Text;

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

        public override List<string> GetMembersList()
        {
            List<string> members = new List<string>();

            members.AddRange(base.GetMembersList());
            members.AddRange(CarInfo.GetMembersList());

            return members;
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