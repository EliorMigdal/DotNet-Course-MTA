namespace GarageLogic.Vehicles.Types.Objects.MotorCycle
{
    public class FueledMotorCycle : FueledVehicle
    {
        public FueledMotorCycle()
        {
            InstallWheels((int)eNumOfWheels.MotorCycle, (float)eMaxWheelAirPressure.MotorCycle);
            InitializeFuelData(eFuelType.Octan98, 5.8f);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}