using System.Collections.Generic;

namespace GarageLogic.Vehicles.Types.Objects.Truck
{
    public class Truck : FueledVehicle
    {
        public TruckInfo TruckInfo { get; set; }

        public Truck()
        {
            InstallWheels((int)eNumOfWheels.Truck, (float)eMaxWheelAirPressure.Truck);
        }
    }
}