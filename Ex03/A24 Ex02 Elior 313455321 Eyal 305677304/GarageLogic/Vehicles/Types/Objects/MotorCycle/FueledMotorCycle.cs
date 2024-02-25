using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.MotorCycle
{
    public class FueledMotorCycle : FueledVehicle
    {
        public MotorCycleInfo MotorCycleInfo { get; set; }

        public FueledMotorCycle()
        {
            InstallWheels((int)eNumOfWheels.MotorCycle, (float)eMaxWheelAirPressure.MotorCycle);
            FuelType = eFuelType.Octan98;
            MaxFuelCapacity = 5.8f;
        }

        public override List<string> GetMembersList()
        {
            List<string> members = new List<string>();

            members.AddRange(base.GetMembersList());
            members.AddRange(MotorCycleInfo.GetMembersList());

            return members;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.Append(MotorCycleInfo.ToString());

            return stringBuilder.ToString();
        }
    }
}