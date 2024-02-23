using System.Text;

namespace GarageLogic.Vehicles
{
    public class VehicleInfo
    {
        public string Model { get; set; }
        public string LicenseID { get; set; }
        public float RemainingEnergyPercentage { get; set; }

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