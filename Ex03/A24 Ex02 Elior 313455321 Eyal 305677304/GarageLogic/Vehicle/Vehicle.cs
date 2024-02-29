using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicles
{
    public abstract class Vehicle
    {
        public VehicleInfo VehicleInfo { get; set; }
        public List<Wheel> Wheels { get; set; }

        protected void InstallWheels(int i_NumOfWheels, float i_MaxAirPressure)
        {
            Wheels = new List<Wheel>(i_NumOfWheels);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel wheel = new Wheel
                {
                    MaxAirPressure = i_MaxAirPressure
                };

                Wheels.Add(wheel);
            }
        }

        public void InflateTiresToMaximum()
        {
            foreach (Wheel wheel in Wheels)
            {
                wheel.CurrentAirPressure = wheel.MaxAirPressure;
            }
        }

        public override string ToString()
        {
            StringBuilder vehicleData = new StringBuilder();

            vehicleData.AppendLine(VehicleInfo.ToString());
            vehicleData.AppendLine("Vehicle's wheels information:");

            foreach (Wheel wheel in Wheels)
            {
                vehicleData.AppendLine($"Wheel #{Wheels.IndexOf(wheel) + 1}:");
                vehicleData.AppendLine(wheel.ToString());
            }

            return vehicleData.ToString();
        }
    }
}