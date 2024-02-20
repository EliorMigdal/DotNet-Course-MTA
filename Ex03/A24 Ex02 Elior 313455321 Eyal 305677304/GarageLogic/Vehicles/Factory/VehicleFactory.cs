using GarageLogic.Vehicles.Types.Objects.Car;
using GarageLogic.Vehicles.Types.Objects.MotorCycle;
using GarageLogic.Vehicles.Types.Objects.Truck;

namespace GarageLogic.Vehicles.Factory
{
    internal class VehicleFactory
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
    }
}