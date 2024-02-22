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
    }
}