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

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(MotorCycleInfo.ToString());

            return stringBuilder.ToString();
        }
    }
}