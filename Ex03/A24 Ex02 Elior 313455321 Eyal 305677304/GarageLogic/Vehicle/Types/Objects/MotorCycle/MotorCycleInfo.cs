using System;
using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.MotorCycle
{
    public class MotorCycleInfo : VehicleInfo
    {
        public enum eMotorCycleLicense : uint
        {
            A1 = 1,
            A2 = 2,
            AB = 3,
            B = 4
        }

        public eMotorCycleLicense MotorCycleLicense { get; private set; }
        public uint EngineVolume { get; set; }

        public void SetMotorLicence(string i_LicenseInput)
        {
            MotorCycleLicense = validateMotorCycleLicense(i_LicenseInput);
        }

        private eMotorCycleLicense validateMotorCycleLicense(string i_License)
        {
            eMotorCycleLicense licenseType;

            if (!Enum.IsDefined(typeof(eMotorCycleLicense), i_License))
            {
                throw new ArgumentException("Invalid Motorcycle license choice!");
            }

            else
            {
                Enum.TryParse(i_License, out licenseType);
            }

            return licenseType;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine($"Motorcycle license: {MotorCycleLicense}");
            stringBuilder.AppendLine($"Motorcycle engine volume: {EngineVolume}");

            return stringBuilder.ToString();
        }
    }
}