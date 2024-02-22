using ConsoleUI.UI.Enums;
using GarageLogic.Vehicles.Factory;
using GarageLogic.Vehicles.Types.Objects.Car;
using GarageLogic.Vehicles.Types.Objects.MotorCycle;
using System;

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
            Console.WriteLine("Please choose your desired action:");
            Console.WriteLine(string.Format(
                "{0} - Add a new vehicle to the garge\n" +
                "{1} - Display license plates\n" +
                "{2} - Update existing vehicle's state\n" +
                "{3} - Inflate vehicle's tires\n" +
                "{4} - Fill a vehicel's gas tank\n" +
                "{5} - Charge a vehicle's battry\n" +
                "{6} - Display vehicle's information\n" +
                "{7} - Exit",
                (int)eUserOptions.InsertVehicle, (int)eUserOptions.DisplayLicenses, 
                (int)eUserOptions.UpdateVehicleState, (int)eUserOptions.InflateVehicleTires,
                (int)eUserOptions.FillGas, (int)eUserOptions.ChargeBattery,
                (int)eUserOptions.DisplayVehicleInfo, (int)eUserOptions.Exit));
            Console.Write("Enter your action here: ");
        }

        public void PrintVehicleOptions()
        {
            Console.WriteLine("Please choose vehicle type:");
            Console.WriteLine(string.Format(
                "{0} - Fueled Motortcycle\n" +
                "{1} - Electrical Motorcycle\n" +
                "{2} - Fueled Car\n" +
                "{3} - Electrical Car\n" +
                "{4} - Truck", 
                (int)eVehicleType.FueledMotoryCycle, (int)eVehicleType.ElectricalMotorCycle,
                (int)eVehicleType.FueledCar, (int)eVehicleType.ElectricalCar,
                (int)eVehicleType.Truck));
            Console.Write("Enter your selection here: ");
        }

        public void PrintSupportedMotorCycleLicenses()
        {
            Console.Write("Supported Motorcycle licenses: ");

            foreach (eMotorCycleLicense license in Enum.GetValues(typeof(eMotorCycleLicense)))
            {
                Console.Write($"{license} ");
            }

            Console.WriteLine();
        }

        public void PrintSupportedCarColors()
        {
            Console.Write("Supported Car colors: ");

            foreach (eCarColors color in Enum.GetValues (typeof(eCarColors)))
            {
                Console.Write($"{color} ");
            }

            Console.WriteLine();
        }

        public void PrintSupportedNumOfCarDoors()
        {
            Console.Write("Supported Car doors: ");

            foreach (eCarDoors doorNum in Enum.GetValues(typeof(eCarDoors)))
            {
                Console.Write($"{doorNum}");
            }

            Console.WriteLine();
        }

        public void PrintError(string i_Error)
        {
            Console.WriteLine($"Error: {i_Error}");
        }
    }
}