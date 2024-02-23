using System;

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
                throw new ArgumentException($"Invalid fuel type: Vehicle licensed {VehicleInfo.LicenseID} accepts fuel type " +
                    $"{FuelType}, not {i_FuelType}!");
            }
        }

        private void validateFuelAmount(float i_FuelAmount)
        {
            if (i_FuelAmount + RemainingFuel > MaxFuelCapacity)
            {
                throw new ArgumentException($"Denied: Vehicle licensed {VehicleInfo.LicenseID} has already {RemainingFuel} litres" +
                    $"of fuel. Adding {i_FuelAmount} is out of vehicle's capacity!");
            }
        }
    }
}