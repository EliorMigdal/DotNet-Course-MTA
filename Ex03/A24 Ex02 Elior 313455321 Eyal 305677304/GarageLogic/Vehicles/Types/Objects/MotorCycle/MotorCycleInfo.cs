using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.MotorCycle
{
    public class MotorCycleInfo
    {
        public eMotorCycleLicense MotorCycleLicense { get; set; }
        public int EngineVolume { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Motorcycle license: {MotorCycleLicense}");
            stringBuilder.AppendLine($"Motorcycle engine volume: {EngineVolume}");

            return stringBuilder.ToString();
        }
    }
}