using System;

namespace ConsoleUI.UI.Reader
{
    internal class InputReader
    {
        public string ReadUserAction()
        {
            Console.Write("Enter your desired action: ");

            return Console.ReadLine();
        }

        public string ReadVehicleType()
        {
            Console.Write("Enter your desired vehicle type: ");

            return Console.ReadLine();
        }

        public string ReadLicensePlate()
        {
            Console.Write("Please enter vehicle's license plate: ");

            return Console.ReadLine();
        }

        public string ReadVehicleModel()
        {
            Console.Write("Please enter vehicle's model: ");

            return Console.ReadLine();
        }

        public string ReadEnergyPercentage()
        {
            Console.Write("Please enter vehicle's remaining energy percentage: ");

            return Console.ReadLine();
        }

        public string ReadWheelManufacturorName()
        {
            Console.Write("Please enter wheels manufacturor name: ");

            return Console.ReadLine();
        }

        public string ReadWheelCurrentAirPressure()
        {
            Console.Write("Please enter wheels current air pressure: ");

            return Console.ReadLine();
        }

        public string ReadMotorCycleLicense()
        {
            Console.Write("Please enter motorcycle's license: ");

            return Console.ReadLine();
        }

        public string ReadMotorCycleEngineVolume()
        {
            Console.Write("Please enter motorcycle's engine volume: ");

            return Console.ReadLine();
        }

        public string ReadCarColor()
        {
            Console.Write("Please enter car's color: ");

            return Console.ReadLine();
        }

        public string ReadNumOfCarDoors()
        {
            Console.Write("Please enter num of car's doors: ");

            return Console.ReadLine();
        }

        public string ReadDangerousLuggageInfo()
        {
            Console.Write("Please enter whether your truck carries dangerous luggage.\nEnter Y/N: ");

            return Console.ReadLine();
        }

        public string ReadLuggageCapacity()
        {
            Console.Write("Please enter truck's luggage capacity: ");

            return Console.ReadLine();
        }

        public string ReadOwnerName()
        {
            Console.Write("Please enter vehicle's owner name: ");

            return Console.ReadLine();
        }

        public string ReadOwnerPhone()
        {
            Console.Write("Please enter vehicle's owner phone number: ");

            return Console.ReadLine();
        }

        public string ReadVehicleStatus()
        {
            Console.Write("Please enter vehicle's status (or enter 'All'): ");

            return Console.ReadLine();
        }

        public string ReadNewVehicleState()
        {
            Console.Write("Please enter vehicle's new state: ");

            return Console.ReadLine();
        }

        public string ReadFuelType()
        {
            Console.Write("Please enter the type of fuel you would like to fill: ");

            return Console.ReadLine();
        }

        public string ReadFuelAmount()
        {
            Console.Write("Please enter the amount of fuel (In Litres) you would like to fill: ");

            return Console.ReadLine();
        }

        public string ReadBatteryAmount()
        {
            Console.Write("Please enter the number of minutes you would like to charge the vehicle: ");

            return Console.ReadLine();
        }
    }
}