using GarageLogic.Vehicles;
using System.Collections.Generic;

namespace GarageLogic.Manager
{
    internal class GarageManager
    {
        private readonly List<Vehicle> r_Vehicles = new List<Vehicle>();
        private readonly Dictionary<string, VehicleRecord> r_VehicleRecords 
            = new Dictionary<string, VehicleRecord>();

        public bool IsVehicleInGarage(string i_LicesnePlate)
        {
            return r_VehicleRecords.ContainsKey(i_LicesnePlate);
        }
    }
}