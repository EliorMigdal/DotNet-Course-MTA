using GarageLogic.Vehicles;
using GarageLogic.Vehicles.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GarageLogic.Manager
{
    public class GarageManager
    {
        private readonly List<Vehicle> r_Vehicles = new List<Vehicle>();
        private readonly Dictionary<string, VehicleRecord> r_VehicleRecords 
            = new Dictionary<string, VehicleRecord>();

        public void InsertNewVehicle(Vehicle i_Vehicle, VehicleRecord i_VehicleRecord)
        {
            r_Vehicles.Add(i_Vehicle);
            r_VehicleRecords.Add(i_Vehicle.VehicleInfo.LicenseID, i_VehicleRecord);
        }

        public bool IsVehicleInGarage(string i_LicesnePlate)
        {
            return r_VehicleRecords.ContainsKey(i_LicesnePlate);
        }

        public List<string> FilterLicensePlatesByStatus(string i_VehicleStatus)
        {
            eVehicleStatus vehicleStatus;

            validateVehicleStatus(i_VehicleStatus, out vehicleStatus);

            List<string> result = r_VehicleRecords
                .Where(pair => i_VehicleStatus.Equals("All") || pair.Value.Status.Equals(vehicleStatus))
                .Select(pair => pair.Key)
                .ToList();

            return result;
        }

        public string UpdateVehicleState(string i_LicensePlate, string i_VehicleState)
        {
            eVehicleStatus vehicleStatus;
            string oldState;

            verifyVehicleExistsInGarage(i_LicensePlate);
            validateVehicleStatus(i_VehicleState, out vehicleStatus);

            oldState = r_VehicleRecords[i_LicensePlate].Status.ToString();
            r_VehicleRecords[i_LicensePlate].Status = vehicleStatus;

            return oldState;
        }

        public void InflateVehicleTiresToMaximum(string i_LicensePlate)
        {
            Vehicle vehicle = findVehicle(i_LicensePlate);
            vehicle.InflateTiresToMaximum();
        }

        public float FillGas(string i_LicensePlate, string i_FuelType, float i_FuelAmount)
        {
            Vehicle vehicle = findVehicle(i_LicensePlate);

            if (vehicle is ElectricalVehicle)
            {
                throw new ArgumentException($"Vehicle licensed {i_LicensePlate} is electrical!");
            }

            FueledVehicle fueledVehicle = vehicle as FueledVehicle;
            validateFuelType(i_FuelType, out eFuelType fuelType);
            fueledVehicle.AddFuel(i_FuelAmount, fuelType);

            return fueledVehicle.RemainingFuel;
        }

        public float ChargeBattery(string i_LicensePlate, float i_ChargingTime)
        {
            Vehicle vehicle = findVehicle(i_LicensePlate);

            if (vehicle is FueledVehicle)
            {
                throw new ArgumentException($"Vehicle licensed {i_LicensePlate} is fueled!");
            }

            ElectricalVehicle electricalVehicle = vehicle as ElectricalVehicle;
            electricalVehicle.ChargeBattery(i_ChargingTime / 60f);

            return electricalVehicle.RemainingBatteryTime;
        }

        public string GetVehicleInfo(string i_LicensePlate)
        {
            StringBuilder vehicleInfo = new StringBuilder();
            Vehicle vehicle;

            vehicle = findVehicle(i_LicensePlate);
            vehicleInfo.AppendLine(r_VehicleRecords[i_LicensePlate].ToString());
            vehicleInfo.AppendLine(vehicle.ToString());

            return vehicleInfo.ToString();
        }

        private bool isStatusValid(string i_Status, out eVehicleStatus o_VehicleStatus)
        {
            bool isStatusValid = i_Status.Equals("All");

            o_VehicleStatus = eVehicleStatus.Fixing;

            if (!isStatusValid)
            {
                foreach (eVehicleStatus status in Enum.GetValues(typeof(eVehicleStatus)))
                {
                    if (Enum.TryParse(i_Status, true, out o_VehicleStatus))
                    {
                        isStatusValid = true; 
                        break;
                    }
                }
            }

            return isStatusValid;
        }

        private void verifyVehicleExistsInGarage(string i_LicensePlate)
        {
            if (!IsVehicleInGarage(i_LicensePlate))
            {
                throw new ArgumentException($"Vehicle licensed {i_LicensePlate} doesn't exist in our garage!");
            }
        }

        private void validateVehicleStatus(string i_Status, out eVehicleStatus o_VehicleStatus)
        {
            if (!isStatusValid(i_Status, out o_VehicleStatus))
            {
                throw new ArgumentException($"Invalid vehicle status: {i_Status}");
            }
        }

        private void validateFuelType(string i_FuelType, out eFuelType o_FuelType)
        {
            if (!Enum.TryParse(i_FuelType, true, out o_FuelType))
            {
                throw new FormatException($"Invalid fuel type: {i_FuelType}");
            }
        }

        private Vehicle findVehicle(string i_LicensePlate)
        {
            verifyVehicleExistsInGarage(i_LicensePlate);

            return r_Vehicles.FirstOrDefault(vehicle => vehicle.VehicleInfo.LicenseID.Equals(i_LicensePlate));
        }
    }
}