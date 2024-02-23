﻿using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.Truck
{
    public class TruckInfo
    {
        public bool HasDangerousLuggage { get; set; }
        public float LuggageCapacity { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Does truck move dangerous luggage?: {(HasDangerousLuggage ? "Yes" : "No")}");
            stringBuilder.AppendLine($"Truck's luggage capacity: {LuggageCapacity}");
            
            return stringBuilder.ToString();
        }
    }
}