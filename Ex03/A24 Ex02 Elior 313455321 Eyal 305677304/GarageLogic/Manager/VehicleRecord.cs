using System.Text;

namespace GarageLogic.Manager
{
    public class VehicleRecord
    {
        public Owner Owner { get; set; }
        public eVehicleStatus Status { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(Owner.ToString());
            stringBuilder.AppendLine($"Vehicle status: {Status}");

            return stringBuilder.ToString();
        }
    }
}