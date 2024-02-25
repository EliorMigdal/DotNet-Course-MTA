using GarageLogic.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace GarageLogic.Vehicles
{
    public class VehicleInfo
    {
        public string Model { get; set; }
        public string LicenseID { get; set; }
        private float m_RemainingEnergyPercentage;
        public float RemainingEnergyPercentage 
        { 
            get
            {
                return m_RemainingEnergyPercentage;
            }
            
            set
            {
                if (value < 0f || value > 100f)
                {
                    throw new ValueOutOfRangeException("Energy Percentage", 0f, 100f);
                }

                m_RemainingEnergyPercentage = value;
            }
        }

        public static List<string> GetDataMembers()
        {
            return new List<string>
            {
                "Vehicle Model",
                "Vehicle license plate",
                "Remaining energy percentage"
            };
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Vehicle Licence ID: {LicenseID}");
            stringBuilder.AppendLine($"Vehicle Model: {Model}");
            stringBuilder.AppendLine($"Vehicle remainig energy percentage: {RemainingEnergyPercentage}");

            return stringBuilder.ToString();
        }
    }
}