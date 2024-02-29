using ConsoleUI.UI.Enums;
using GarageLogic.Manager;
using GarageLogic.Vehicles.Factory;
using System;
using System.Collections.Generic;
using static GarageLogic.Vehicles.Types.FueledVehicle;
using static GarageLogic.Vehicles.Types.Objects.Car.CarInfo;
using static GarageLogic.Vehicles.Types.Objects.MotorCycle.MotorCycleInfo;

namespace ConsoleUI.UI.Printer
{
    internal class OutputPrinter
    {
        public void GreetUser()
        {
            Console.WriteLine("Welcome to the Garage Management System!");
        }

        public void PrintUserOptions()
        {
            Console.Write("Please choose your desired action:");
            Console.WriteLine(string.Format(@"
                {0} - Add a new vehicle to the garage
                {1} - Display license plates
                {2} - Update existing vehicle's state
                {3} - Inflate vehicle's tires
                {4} - Fill a vehicle's gas tank
                {5} - Charge a vehicle's battery
                {6} - Display vehicle's information
                {7} - Exit",
                (int)eUserOptions.InsertVehicle, (int)eUserOptions.DisplayLicenses,
                (int)eUserOptions.UpdateVehicleState, (int)eUserOptions.InflateVehicleTires,
                (int)eUserOptions.FillGas, (int)eUserOptions.ChargeBattery,
                (int)eUserOptions.DisplayVehicleInfo, (int)eUserOptions.Exit));
        }

        public void PrintVehicleOptions()
        {
            Console.Write("Supported Vehicle types: ");
            Console.WriteLine(string.Format(@"
                {0} - Fueled Motorcycle
                {1} - Electrical Motorcycle
                {2} - Fueled Car
                {3} - Electrical Car
                {4} - Truck",
                (int)eVehicleType.FueledMotorCycle, (int)eVehicleType.ElectricalMotorCycle,
                (int)eVehicleType.FueledCar, (int)eVehicleType.ElectricalCar,
                (int)eVehicleType.Truck));
        }

        public void PrintSupportedMotorCycleLicenses()
        {
            Console.WriteLine("Supported Motorcycle licenses: ");

            foreach (eMotorCycleLicense license in Enum.GetValues(typeof(eMotorCycleLicense)))
            {
                Console.WriteLine($"-  {license}");
            }
        }

        public void PrintSupportedCarColors()
        {
            Console.WriteLine("Supported Car colors: ");

            foreach (eCarColors color in Enum.GetValues(typeof(eCarColors)))
            {
                Console.WriteLine($"- {color}");
            }
        }

        public void PrintSupportedNumOfCarDoors()
        {
            Console.WriteLine("Supported Car doors: ");

            foreach (eCarDoors doorNum in Enum.GetValues(typeof(eCarDoors)))
            {
                Console.WriteLine($"- {(int)doorNum}");
            }
        }

        public void PrintVehicleStatuses()
        {
            Console.WriteLine("Available vehicle statuses: ");

            foreach (eVehicleStatus status in Enum.GetValues(typeof(eVehicleStatus)))
            {
                Console.WriteLine($"- {status}");
            }
        }

        public void PrintLicensePlates(string i_VehicleStatus, List<string> i_Licenses)
        {
            if (i_Licenses.Count == 0)
            {
                Console.WriteLine($"There are no vehicles under status {i_VehicleStatus.ToLower()}.");
            }

            else
            {
                Console.WriteLine($"List of {i_VehicleStatus.ToLower()} vehicles's license plates:");

                foreach (string license in i_Licenses)
                {
                    Console.WriteLine(license);
                }
            }
        }

        public void PrintFuelTypes()
        {
            Console.WriteLine("List of available fuel types:");

            foreach (eFuelType fuelType in Enum.GetValues(typeof(eFuelType)))
            {
                Console.WriteLine($"- {fuelType}");
            }
        }

        public void PrintError(string i_Error)
        {
            Console.WriteLine($"Error: {i_Error}\n");
        }
    }
}