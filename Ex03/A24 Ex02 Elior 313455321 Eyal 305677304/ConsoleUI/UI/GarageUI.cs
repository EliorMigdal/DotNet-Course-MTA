using ConsoleUI.UI.Enums;
using ConsoleUI.UI.Printer;
using ConsoleUI.UI.Reader;
using ConsoleUI.UI.Validator;
using GarageLogic.Vehicles.Factory;
using GarageLogic.Vehicles;
using System;
using GarageLogic.Manager;
using GarageLogic.Vehicles.Types.Objects.MotorCycle;
using GarageLogic.Vehicles.Types.Objects.Car;
using GarageLogic.Vehicles.Types.Objects.Truck;
using System.Collections.Generic;
using GarageLogic.Exceptions;

namespace ConsoleUI.UI
{
    public class GarageUI
    {
        private readonly OutputPrinter r_OutputPrinter = new OutputPrinter();
        private readonly InputReader r_InputReader = new InputReader();
        private readonly InputValidator r_InputValidator = new InputValidator();
        private readonly VehicleFactory r_VehicleFactory = new VehicleFactory();
        private readonly GarageManager r_GarageManager = new GarageManager();

        public void RunSystem()
        {
            bool hasUserExited = false;
            string userInput;

            r_OutputPrinter.GreetUser();
            
            while (!hasUserExited)
            {
                try
                {
                    userInput = handleActionChoice();
                    r_InputValidator.ValidateActionChoice(userInput, out eUserOptions userChoice);
                    executeUserAction(userChoice);
                    hasUserExited = userChoice.Equals(eUserOptions.Exit);
                }

                catch (Exception e)
                {
                    r_OutputPrinter.PrintError(e.Message);
                }
            }
        }

        private string handleActionChoice()
        {
            r_OutputPrinter.PrintUserOptions();

            return r_InputReader.ReadUserAction();
        }

        private void executeUserAction(eUserOptions i_UserChoice)
        {
            switch (i_UserChoice)
            {
                case eUserOptions.InsertVehicle:
                    insertNewVehicle();
                    break;

                case eUserOptions.DisplayLicenses:
                    displayLicenses();
                    break;

                case eUserOptions.UpdateVehicleState:
                    updateVehicleState();
                    break;

                case eUserOptions.InflateVehicleTires:
                    inflateVehicleTires();
                    break;

                case eUserOptions.FillGas:
                    fillGas();
                    break;

                case eUserOptions.ChargeBattery:
                    chargeBattery();
                    break;

                case eUserOptions.DisplayVehicleInfo:
                    displayVehicleInfo();
                    break;

                case eUserOptions.Exit:
                    break;

                default:
                    break;
            }
        }

        private void insertNewVehicle()
        {
            bool successfullyInserted = false;

            while (!successfullyInserted)
            {
                try
                {
                    uint vehicleInput = readVehicleType();
                    Vehicle generatedVehicle = r_VehicleFactory.GenerateVehicle(vehicleInput, 
                        out eVehicleType vehicleType);
                    Owner vehicleOwner = readOwnerInfo();
                    readVehicleInfo(generatedVehicle, vehicleType);
                    r_GarageManager.InsertNewVehicle(generatedVehicle, vehicleOwner);
                    Console.WriteLine("Successfully Inserted!");
                    successfullyInserted = true;
                }

                catch (VehicleAlreadyExistsException e)
                {
                    throw e;
                }

                catch (Exception e)
                {
                    r_OutputPrinter.PrintError(e.Message);
                }
            }
        }

        private uint readVehicleType()
        {
            string userInput;

            r_OutputPrinter.PrintVehicleOptions();
            userInput = r_InputReader.ReadVehicleType();
            r_InputValidator.TryParsingToUnsignedInt(userInput, out uint parsedInput);

            return parsedInput;
        }

        private void readVehicleInfo(Vehicle i_Vehicle, eVehicleType i_VehicleType)
        {
            bool successfullyRead = false;

            while (!successfullyRead)
            {
                try
                {
                    handleVehicleData(i_Vehicle);
                    handleWheelData(i_Vehicle);
                    handleUniqueVehicleTypeData(i_Vehicle, i_VehicleType);
                    successfullyRead = true;
                }

                catch (VehicleAlreadyExistsException e)
                {
                    throw e;
                }

                catch (Exception e)
                {
                    r_OutputPrinter.PrintError($"{e.Message}");
                }
            }
        }

        private void handleVehicleData(Vehicle i_Vehicle)
        {
            bool successfullyRead = false;

            while (!successfullyRead)
            {
                try
                {
                    readVehicleData(out string licenseInput, out string modelInput, out string energyInput);
                    r_InputValidator.TryParsingToFloat(energyInput, out float energyPercentage);
                    insertVehicleInfo(i_Vehicle, modelInput, licenseInput, energyPercentage);
                    successfullyRead = true;
                }

                catch(VehicleAlreadyExistsException e)
                {
                    throw e;
                }

                catch(Exception e)
                {
                    r_OutputPrinter.PrintError(e.Message);
                }
            }
        }

        private void handleWheelData(Vehicle i_Vehicle)
        {
            bool successfullyRead = false;

            while (!successfullyRead)
            {
                try
                {
                    readWheelData(out string manufacturorName, out string airPressureInput);
                    r_InputValidator.TryParsingToFloat(airPressureInput, out float airPressure);
                    insertWheelInfo(i_Vehicle, manufacturorName, airPressure);
                    successfullyRead = true;
                }

                catch (Exception e)
                {
                    r_OutputPrinter.PrintError(e.Message);
                }
            }
        }

        private Owner readOwnerInfo()
        {
            return new Owner
            {
                Name = r_InputReader.ReadOwnerName(),
                Phone = r_InputReader.ReadOwnerPhone()
            };
        }

        private void readVehicleData(out string o_License, out string o_Model, out string o_Energy)
        {
            o_License = r_InputReader.ReadLicensePlate();
            r_GarageManager.VerifyVehicleDoesNotExistInGarage(o_License);
            o_Model = r_InputReader.ReadVehicleModel();
            o_Energy = r_InputReader.ReadEnergyPercentage();
        }

        private void readWheelData(out string o_ManufacturorName, out string o_CurrentAirPressure)
        {
            o_ManufacturorName = r_InputReader.ReadWheelManufacturorName();
            o_CurrentAirPressure = r_InputReader.ReadWheelCurrentAirPressure();
        }

        private void insertVehicleInfo(Vehicle i_Vehicle, string i_Model, string i_License, float i_EnergyPercentage)
        {
            i_Vehicle.VehicleInfo.RemainingEnergyPercentage = i_EnergyPercentage;
            i_Vehicle.VehicleInfo.Model = i_Model;
            i_Vehicle.VehicleInfo.LicenseID = i_License;
        }

        private void insertWheelInfo(Vehicle i_Vehicle, string i_ManufacturorName, float i_CurrentAirPressure)
        {
            foreach (Wheel wheel in i_Vehicle.Wheels)
            {
                wheel.ManufacturerName = i_ManufacturorName;
                wheel.CurrentAirPressure = i_CurrentAirPressure;
            }
        }

        private void handleUniqueVehicleTypeData(Vehicle i_Vehicle, eVehicleType i_VehicleType)
        {
            bool successfullyRead = false;

            while (!successfullyRead)
            {
                try
                {
                    switch (i_VehicleType)
                    {
                        case eVehicleType.FueledMotorCycle:
                        case eVehicleType.ElectricalMotorCycle:
                            readMotorCycleData(i_Vehicle);
                            break;

                        case eVehicleType.FueledCar:
                        case eVehicleType.ElectricalCar:
                            readCarData(i_Vehicle);
                            break;

                        case eVehicleType.Truck:
                            readTruckData(i_Vehicle);
                            break;

                        default:
                            break;
                    }

                    successfullyRead = true;
                }

                catch (Exception e)
                {
                    r_OutputPrinter.PrintError(e.Message);
                }
            }
        }

        private void readMotorCycleData(Vehicle i_MotorCycle)
        {
            MotorCycleInfo motorCycleInfo = i_MotorCycle.VehicleInfo as MotorCycleInfo;
            string licenseInput;

            licenseInput = readMotorCycleLicense();
            motorCycleInfo.SetMotorLicence(licenseInput);
            motorCycleInfo.EngineVolume = readMotorCycleEngineVolume();
        }

        private string readMotorCycleLicense()
        {
            string licenseInput;

            r_OutputPrinter.PrintSupportedMotorCycleLicenses();
            licenseInput = r_InputReader.ReadMotorCycleLicense();

            return licenseInput;
        }

        private uint readMotorCycleEngineVolume()
        {
            string engineVolumeInput;

            engineVolumeInput = r_InputReader.ReadMotorCycleEngineVolume();
            r_InputValidator.TryParsingToUnsignedInt(engineVolumeInput, out uint engineVolume);

            return engineVolume;
        }

        private void readCarData(Vehicle i_Car)
        {
            CarInfo carInfo = i_Car.VehicleInfo as CarInfo;
            string colorInput;
            uint doorInput;

            colorInput = readCarColor();
            doorInput = readCarNumOfDoors();
            carInfo.SetCarColor(colorInput);
            carInfo.SetNumOfDoors(doorInput);
        }

        private string readCarColor()
        {
            string colorInput;

            r_OutputPrinter.PrintSupportedCarColors();
            colorInput = r_InputReader.ReadCarColor();

            return colorInput;
        }

        private uint readCarNumOfDoors()
        {
            string doorsInput;

            r_OutputPrinter.PrintSupportedNumOfCarDoors();
            doorsInput = r_InputReader.ReadNumOfCarDoors();
            r_InputValidator.TryParsingToUnsignedInt(doorsInput, out uint carDoors);

            return carDoors;
        }

        private void readTruckData(Vehicle i_Truck)
        {
            TruckInfo truckInfo = i_Truck.VehicleInfo as TruckInfo;

            truckInfo.HasDangerousLuggage = readDangerousLuggageData();
            truckInfo.LuggageCapacity = readLuggageCapacity();
        }

        private bool readDangerousLuggageData()
        {
            string dangerousLuggageInput;

            dangerousLuggageInput = r_InputReader.ReadDangerousLuggageInfo();
            r_InputValidator.ValidateDangerousLuggageInput(dangerousLuggageInput, out bool hasDangerousLuggage);

            return hasDangerousLuggage;
        }

        private float readLuggageCapacity()
        {
            string luggageCapacityInput;

            luggageCapacityInput = r_InputReader.ReadLuggageCapacity();
            r_InputValidator.TryParsingToFloat(luggageCapacityInput, out float luggageCapacity);

            return luggageCapacity;
        }

        private void displayLicenses()
        {
            string vehicleStatus;
            List<string> licenses;

            r_OutputPrinter.PrintVehicleStatuses();
            vehicleStatus = r_InputReader.ReadVehicleStatus();
            licenses = r_GarageManager.FilterLicensePlatesByStatus(vehicleStatus);
            r_OutputPrinter.PrintLicensePlates(vehicleStatus, licenses);
        }

        private void updateVehicleState()
        {
            string licensePlate, newState, oldState;
            
            licensePlate = r_InputReader.ReadLicensePlate();
            newState = r_InputReader.ReadNewVehicleState();
            oldState = r_GarageManager.UpdateVehicleState(licensePlate, newState);
            Console.WriteLine($"Successfully updated vehicle licensed {licensePlate}'s state from {oldState} to {newState}!");
        }

        private void inflateVehicleTires()
        {
            string licensePlate = r_InputReader.ReadLicensePlate();

            r_GarageManager.InflateVehicleTiresToMaximum(licensePlate);
            Console.WriteLine($"Successfully inflated vehicle licensed {licensePlate}'s wheels!");
        }

        private void fillGas()
        {
            string licensePlate, fuelType, fuelAmountInput;
            float newAmount;
            
            licensePlate = r_InputReader.ReadLicensePlate();
            r_OutputPrinter.PrintFuelTypes();
            fuelType = r_InputReader.ReadFuelType();
            fuelAmountInput = r_InputReader.ReadFuelAmount();
            r_InputValidator.TryParsingToFloat(fuelAmountInput, out float fuelAmount);
            newAmount = r_GarageManager.FillGas(licensePlate, fuelType, fuelAmount);
            Console.WriteLine($"Successfully filled {fuelAmount} litres of gas in vehicle " +
                $"licensed {licensePlate}. New amount: {newAmount}L");
        }

        private void chargeBattery()
        {
            string licensePlate, chargingTimeInput;
            float newAmount;

            licensePlate = r_InputReader.ReadLicensePlate();
            chargingTimeInput = r_InputReader.ReadBatteryAmount();
            r_InputValidator.TryParsingToFloat(chargingTimeInput, out float chargingTime);
            newAmount = r_GarageManager.ChargeBattery(licensePlate, chargingTime);
            Console.WriteLine($"Successfully charged {chargingTime / 60f:F2} hours of battery in vehicle " +
                $"licensed {licensePlate}. New amount: {newAmount:F2}H");
        }

        private void displayVehicleInfo()
        {
            string licensePlate, vehicleInfo;

            licensePlate = r_InputReader.ReadLicensePlate();
            vehicleInfo = r_GarageManager.GetVehicleInfo(licensePlate);
            Console.Write(vehicleInfo);
        }
    }
}