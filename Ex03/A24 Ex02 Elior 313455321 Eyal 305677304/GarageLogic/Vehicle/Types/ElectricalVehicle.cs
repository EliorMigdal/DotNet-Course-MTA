using GarageLogic.Exceptions;
using System;
using System.Text;

namespace GarageLogic.Vehicles.Types
{
    public abstract class ElectricalVehicle : Vehicle
    {
        public float RemainingBatteryTime
        {
            get
            {
                return MaxBatteryTime * VehicleInfo.RemainingEnergyPercentage / 100;
            }
        }
        public float MaxBatteryTime { get; set; }

        public void ChargeBattery(float i_ChargingTime)
        {
            validateChargingTime(i_ChargingTime);
            VehicleInfo.RemainingEnergyPercentage = (RemainingBatteryTime + 
                i_ChargingTime) * 100 / MaxBatteryTime;
        }

        private void validateChargingTime(float i_ChargingTime) 
        {
            if (i_ChargingTime <= 0)
            {
                throw new ArgumentException("Cannot add a non-positive amount of fuel!");
            }

            else if (i_ChargingTime + RemainingBatteryTime > MaxBatteryTime)
            {
                throw new ValueOutOfRangeException("Battery Time", 0f, MaxBatteryTime);
            }
        }

        protected void InitializeMaxBatteryTime(float i_MaxTime)
        {
            MaxBatteryTime = i_MaxTime;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine($"Remaining battery time: {RemainingBatteryTime:F2}H");
            stringBuilder.AppendLine($"Maximum battery time: {MaxBatteryTime:F2}H");

            return stringBuilder.ToString();
        }
    }
}