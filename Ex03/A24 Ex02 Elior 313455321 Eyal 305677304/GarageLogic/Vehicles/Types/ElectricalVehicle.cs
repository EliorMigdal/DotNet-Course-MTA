using System;
using System.Text;

namespace GarageLogic.Vehicles.Types
{
    public abstract class ElectricalVehicle : Vehicle
    {
        public float RemainingBatteryTime { get; set; }
        public float MaxBatteryTime { get; set; }

        public void ChargeBattery(float i_ChargingTime)
        {
            validateChargingTime(i_ChargingTime);
            RemainingBatteryTime += i_ChargingTime;
        }

        private void validateChargingTime(float i_ChargingTime) 
        {
            if (i_ChargingTime <= 0)
            {
                throw new ArgumentException("Cannot add a non-positive amount of fuel!");
            }

            else if (i_ChargingTime + RemainingBatteryTime > MaxBatteryTime)
            {
                throw new ArgumentException($"Denied: Vehicle licensed {VehicleInfo.LicenseID} has already {RemainingBatteryTime} hours " +
                    $"of battery.\nCharging it for {i_ChargingTime}H is out of vehicle's battery capacity!");
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine($"Remaining battery time: {RemainingBatteryTime:F2}H");
            stringBuilder.AppendLine($"Maximum battery time: {MaxBatteryTime:F2}H");

            return stringBuilder.ToString();
        }
    }
}