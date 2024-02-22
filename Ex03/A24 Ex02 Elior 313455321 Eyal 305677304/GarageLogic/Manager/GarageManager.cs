using GarageLogic.Vehicles;
using System.Collections.Generic;

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
    }
}