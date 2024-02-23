using ConsoleUI.UI.Enums;
using ConsoleUI.UI.Exceptions;
using GarageLogic.Exceptions;
using GarageLogic.Vehicles;
using GarageLogic.Vehicles.Factory;
using GarageLogic.Vehicles.Types.Objects.Car;
using GarageLogic.Vehicles.Types.Objects.MotorCycle;
using System;

namespace ConsoleUI.UI.Validator
{
    internal class InputValidator
    {
        public void VerifyActionChoice(string i_Input, out eUserOptions o_Choice)
        {
            tryParsingToInt(i_Input, out int choice);
            o_Choice = (eUserOptions)choice;

            if (choice < (int)eUserOptions.InsertVehicle || choice > (int)eUserOptions.Exit)
            {
                throw new ChoiceOutOfRangeException((int)eUserOptions.InsertVehicle, (int)eUserOptions.Exit);
            }
        }

        public void VerifyVehicleTypeChoice(string i_Input, out eVehicleType o_Choice)
        {
            tryParsingToInt(i_Input, out int choice);
            o_Choice = (eVehicleType)choice;
        }

        public void VerifyEnergyPercentageInput(string i_Input, out float o_EnergyPercentage)
        {
            tryParsingToFloat(i_Input, out o_EnergyPercentage);

            if (o_EnergyPercentage < 0f || o_EnergyPercentage > 100f)
            {
                throw new ValueOutOfRangeException("Energy Percentage", 0f, 100f);
            }
        }

        public void VerifyAirPressureInput(string i_Input, out float o_AirPressure, eVehicleType i_VehicleType)
        {
            float maxAirPressure = getMaxAirPressure(i_VehicleType);

            tryParsingToFloat(i_Input, out o_AirPressure);

            if (o_AirPressure < 0f || o_AirPressure > maxAirPressure)
            {
                throw new ValueOutOfRangeException("Air Pressure", 0f, maxAirPressure);
            }
        }

        public void VerifyMotorCycleLicenseInput(string i_Input, out eMotorCycleLicense o_MotorCycleLicense)
        {
            bool parsable = Enum.TryParse(i_Input, false, out o_MotorCycleLicense);

            if (!parsable)
            {
                throw new ArgumentException("Unsupported motorcycle license!");
            }
        }

        public void VerifyMotorCycleEngineInput(string i_Input, out int o_EngineVolume)
        {
            tryParsingToInt(i_Input,out o_EngineVolume);
        }

        public void VerifyCarColorInput(string i_Input, out eCarColors o_CarColor)
        {
            bool parsable = Enum.TryParse(i_Input, false, out o_CarColor);

            if (!parsable)
            {
                throw new ArgumentException("Unsupported car color!");
            }
        }

        public void VerifyNumOfCarDoorsInput(string i_Input, out eCarDoors o_NumOfCarDoors)
        {
            tryParsingToInt(i_Input, out int numOfDoors);
            o_NumOfCarDoors = (eCarDoors)numOfDoors;

            if (numOfDoors < (int)eCarDoors.TwoDoor || numOfDoors > (int)eCarDoors.FiveDoor)
            {
                throw new ChoiceOutOfRangeException((int)eCarDoors.TwoDoor, (int)eCarDoors.FiveDoor);
            }
        }

        public void VerifyDangerousLuggageInput(string i_Input, out bool o_HasDangerousLuggage)
        {
            if (!i_Input.Equals("Y") && !i_Input.Equals("N"))
            {
                throw new ArgumentException("Invalid choice!");
            }

            o_HasDangerousLuggage = i_Input.Equals("Y");
        }

        public void VerifyLuggageCapacity(string i_Input, out float o_LuggageCapacity)
        {
            tryParsingToFloat(i_Input, out o_LuggageCapacity);
        }

        public void VerifyFuelAmount(string i_Input, out float o_FuelAmount)
        {
            tryParsingToFloat(i_Input,out o_FuelAmount);
        }

        public void ValidateChargingTime(string i_Input, out float o_NumOfMinutes)
        {
            tryParsingToFloat(i_Input, out o_NumOfMinutes);
        }

        private void tryParsingToInt(string i_Input, out int o_Parsed)
        {
            bool parsable = int.TryParse(i_Input, out o_Parsed);

            if (!parsable)
            {
                throw new FormatException($"{i_Input} cannot be parsed to an integer!");
            }
        }

        private void tryParsingToFloat(string i_Input, out float o_Parsed)
        {
            bool parsable = float.TryParse(i_Input, out o_Parsed);

            if (!parsable)
            {
                throw new FormatException($"{i_Input} cannot be parsed to a float!");
            }
        }

        private float getMaxAirPressure(eVehicleType i_VehicleType)
        {
            float maxAirPressure = 0;

            switch (i_VehicleType)
            {
                case eVehicleType.FueledMotoryCycle:
                case eVehicleType.ElectricalMotorCycle:
                    maxAirPressure = (float)eMaxWheelAirPressure.MotorCycle;
                    break;

                case eVehicleType.FueledCar:
                case eVehicleType.ElectricalCar:
                    maxAirPressure = (float)eMaxWheelAirPressure.Car;
                    break;

                case eVehicleType.Truck:
                    maxAirPressure = (float)eMaxWheelAirPressure.Truck;
                    break;

                default:
                    break;
            }

            return maxAirPressure;
        }
    }
}