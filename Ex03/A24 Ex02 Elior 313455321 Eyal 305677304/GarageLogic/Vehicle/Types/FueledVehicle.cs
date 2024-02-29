using GarageLogic.Exceptions;
using System;
using System.Text;

namespace GarageLogic.Vehicles.Types
{
    public abstract class FueledVehicle : Vehicle
    {
        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        }

        public eFuelType FuelType { get; set; }
        public float MaxFuelCapacity { get; set; }
        public float RemainingFuel
        {
            get
            {
                return MaxFuelCapacity * VehicleInfo.RemainingEnergyPercentage / 100;
            }
        }

        public void AddFuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            validateFuelType(i_FuelType);
            validateFuelAmount(i_FuelAmount);
            VehicleInfo.RemainingEnergyPercentage = (RemainingFuel +  
                i_FuelAmount) * 100 / MaxFuelCapacity;
        }

        private void validateFuelType(eFuelType i_FuelType)
        {
            if (!FuelType.Equals(i_FuelType))
            {
                throw new ArgumentException($"Invalid fuel type: Vehicle licensed {VehicleInfo.LicenseID} " +
                    $"accepts fuel type {FuelType}, not {i_FuelType}!");
            }
        }

        private void validateFuelAmount(float i_FuelAmount)
        {
            if (i_FuelAmount + RemainingFuel > MaxFuelCapacity)
            {
                throw new ValueOutOfRangeException("Fuel amount", 0f, MaxFuelCapacity);
            }

            else if (i_FuelAmount <= 0)
            {
                throw new ArgumentException("Cannot add a non-positive amount of fuel!");
            }
        }

        protected void InitializeFuelData(eFuelType i_FuelType, float i_MaxCapacity)
        {
            FuelType = i_FuelType;
            MaxFuelCapacity = i_MaxCapacity;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine($"Fuel type: {FuelType}");
            stringBuilder.AppendLine($"Remaining fuel: {RemainingFuel:F2}L");
            stringBuilder.AppendLine($"Maximum fuel capacity: {MaxFuelCapacity:F2}L");

            return stringBuilder.ToString();
        }
    }
}