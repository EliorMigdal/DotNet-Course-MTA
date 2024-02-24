using GarageLogic.Exceptions;
using System;
using System.Text;

namespace GarageLogic.Vehicles.Types
{
    public abstract class FueledVehicle : Vehicle
    {
        public eFuelType FuelType { get; set; }
        public float RemainingFuel { get; set; }
        public float MaxFuelCapacity { get; set; }

        public void AddFuel(float i_FuelAmount, eFuelType i_FuelType)
        {
            validateFuelType(i_FuelType);
            validateFuelAmount(i_FuelAmount);
            RemainingFuel += i_FuelAmount;
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