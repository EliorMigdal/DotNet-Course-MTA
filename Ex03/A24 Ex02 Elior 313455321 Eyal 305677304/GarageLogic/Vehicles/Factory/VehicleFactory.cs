using GarageLogic.Vehicles.Types.Objects.Car;
using GarageLogic.Vehicles.Types.Objects.MotorCycle;
using GarageLogic.Vehicles.Types.Objects.Truck;
using System;

namespace GarageLogic.Vehicles.Factory
{
    public class VehicleFactory
    {
        public Vehicle GenerateVehicle(eVehicleType i_VehicleType)
        {
            Vehicle generatedVehicle;

            switch (i_VehicleType)
            {
                case eVehicleType.FueledMotoryCycle:
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

            return generatedVehicle;
        }

        public static eVehicleType ValidateVehicleType(uint i_VehicleType)
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
    }
}