using GarageLogic.DTO;
using GarageLogic.DTO.Types;
using GarageLogic.Vehicles.Types.Objects.Car;
using GarageLogic.Vehicles.Types.Objects.MotorCycle;
using GarageLogic.Vehicles.Types.Objects.Truck;
using System.Collections.Generic;

namespace GarageLogic.Vehicles.Factory
{
    internal class VehicleFactory
    {
        public Vehicle GenerateVehicle(eVehicleType i_VehicleType, VehicleForm i_VehicleForm)
        {
            Vehicle generatedVehicle;

            switch (i_VehicleType)
            {
                case eVehicleType.FueledMotoryCycle:
                    generatedVehicle = GenerateFueledMotorCycle(i_VehicleType, i_VehicleForm);
                    break;

                case eVehicleType.ElectricalMotorCycle:
                    generatedVehicle = GenerateElectricalMotorCycle();
                    break;

                case eVehicleType.FueledCar:
                    generatedVehicle = GenerateFueledCar();
                    break;

                case eVehicleType.ElectricalCar:
                    generatedVehicle = GenerateElectricalCar();
                    break;

                case eVehicleType.Truck:
                    generatedVehicle = GenerateTruck();
                    break;

                default:
                    generatedVehicle = null;
                    break;
            }

            return generatedVehicle;
        }

        public Vehicle GenerateFueledMotorCycle(eVehicleType i_VehicleType, VehicleForm i_VehicleForm)
        {
            Vehicle motorCycle;
            
            if (i_VehicleType.Equals(eVehicleType.FueledMotoryCycle))
            {
                motorCycle = new FueledMotorCycle();
            }

            else
            {
                motorCycle = new ElectricalMotorCycle();
            }

            if (i_VehicleForm is MotorCycleForm)
            {
                MotorCycleForm motorCycleForm = i_VehicleForm as MotorCycleForm;

                motorCycle.MotorCycleInfo = motorCycleForm.MotorCycleInfo;
                motorCycle.VehicleInfo = motorCycleForm.VehicleInfo;
                motorCycle.Wheels = new List<Wheel>(2);

                foreach (Wheel wheel in motorCycle.Wheels)
                {
                    wheel.ManufacturerName = motorCycleForm.WheelForm.ManufacturerName;
                    wheel.CurrentAirPressure = motorCycleForm.WheelForm.CurrentAirPressure;
                }
            }

            return motorCycle;
        }

        public ElectricalMotorCycle GenerateElectricalMotorCycle()
        {
            return new ElectricalMotorCycle();
        }

        public FueledCar GenerateFueledCar() { return new FueledCar(); }

        public ElectricalCar GenerateElectricalCar() {  return new ElectricalCar(); }

        public Truck GenerateTruck() { return new Truck(); }
    }
}