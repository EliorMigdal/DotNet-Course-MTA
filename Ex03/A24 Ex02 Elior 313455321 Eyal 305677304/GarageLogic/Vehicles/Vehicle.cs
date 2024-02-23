using System.Collections.Generic;

namespace GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        public VehicleInfo VehicleInfo { get; set; } = new VehicleInfo();
        public List<Wheel> Wheels { get; set; }

        protected void InstallWheels(int i_NumOfWheels, float i_MaxAirPressure)
        {
            Wheels = new List<Wheel>(i_NumOfWheels);

            foreach (Wheel wheel in Wheels)
            {
                wheel.MaxAirPressure = i_MaxAirPressure;
            }
        }

        public void InflateTiresToMaximum()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = wheel.MaxAirPressure;
            }
        }
    }
}