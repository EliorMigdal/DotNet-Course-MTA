using GarageLogic.Vehicles.Types.Objects.Car;
using GarageLogic.Vehicles.Types.Objects.MotorCycle;
using GarageLogic.Vehicles.Types.Objects.Truck;
using System;

namespace GarageLogic.Vehicles.Factory
{
    public class VehicleFactory
    {
        public Vehicle GenerateVehicle(uint i_VehicleType, out eVehicleType o_VehicleType)
        {
            Vehicle generatedVehicle;
            eVehicleType vehicleType = validateVehicleType(i_VehicleType);

            switch (vehicleType)
            {
                case eVehicleType.FueledMotorCycle:
                    generatedVehicle = new FueledMotorCycle();
                    break;

                case eVehicleType.ElectricalMotorCycle:
                    generatedVehicle = new ElectricalMotorCycle();
                    break;

                case eVehicleType.FueledCar:
                    generatedVehicle = new FueledCar();
                    break;

                case eVehicleType.ElectricalCar:
                    generatedVehicle = new ElectricalCar();
                    break;

                case eVehicleType.Truck:
                    generatedVehicle = new Truck();
                    break;

                default:
                    generatedVehicle = null;
                    break;
            }

            o_VehicleType = vehicleType;
            setVehicleInfo(generatedVehicle, vehicleType);

            return generatedVehicle;
        }

        private eVehicleType validateVehicleType(uint i_VehicleType)
        {
            eVehicleType vehicleType;

            if (!Enum.IsDefined(typeof(eVehicleType), i_VehicleType))
            {
                throw new ArgumentException("Invalid vehicle choice!");
            }

            else
            {
                vehicleType = (eVehicleType)i_VehicleType;
            }

            return vehicleType;
        }

        private void setVehicleInfo(Vehicle vehicle, eVehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case eVehicleType.FueledMotorCycle:
                case eVehicleType.ElectricalMotorCycle:
                    vehicle.VehicleInfo = new MotorCycleInfo();
                    break;

                case eVehicleType.FueledCar:
                case eVehicleType.ElectricalCar:
                    vehicle.VehicleInfo = new CarInfo();
                    break;

                case eVehicleType.Truck:
                    vehicle.VehicleInfo = new TruckInfo();
                    break;

                default:
                    break;
            }
        }
    }
}