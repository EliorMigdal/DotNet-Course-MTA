namespace GarageLogic.Vehicles.Types.Objects.MotorCycle
{
    public class ElectricalMotorCycle : ElectricalVehicle
    {
        public ElectricalMotorCycle() 
        {
            InstallWheels((int)eNumOfWheels.MotorCycle, (float)eMaxWheelAirPressure.MotorCycle);
            InitializeMaxBatteryTime(2.8f);
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}