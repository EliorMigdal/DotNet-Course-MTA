using System.Collections.Generic;
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

        public override List<string> GetMembersList()
        {
            List<string> members = new List<string>();

            members.AddRange(base.GetMembersList());
            members.AddRange(TruckInfo.GetMembersList());

            return members;
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