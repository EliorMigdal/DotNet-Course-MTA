using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.MotorCycle
{
    public class ElectricalMotorCycle : ElectricalVehicle
    {
        public MotorCycleInfo MotorCycleInfo { get; set; }

        public ElectricalMotorCycle() 
        {
            InstallWheels((int)eNumOfWheels.MotorCycle, (float)eMaxWheelAirPressure.MotorCycle);
            MaxBatteryTime = 2.8f;
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