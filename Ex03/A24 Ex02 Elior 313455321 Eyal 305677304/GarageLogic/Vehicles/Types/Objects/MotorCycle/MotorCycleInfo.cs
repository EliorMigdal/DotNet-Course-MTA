using System;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.MotorCycle
{
    public class MotorCycleInfo
    {
        public eMotorCycleLicense MotorCycleLicense { get; set; }
        public uint EngineVolume { get; set; }

        public static eMotorCycleLicense ValidateMotorCycleLicense(string i_License)
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

        public static List<string> GetMembersList()
        {
            return new List<string>
            {
                "Motorcycle license",
                "Engine volume"
            };
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Motorcycle license: {MotorCycleLicense}");
            stringBuilder.AppendLine($"Motorcycle engine volume: {EngineVolume}");

            return stringBuilder.ToString();
        }
    }
}