using System;
using System.Text;

namespace GarageLogic.Vehicles
{
    public class Wheel
    {
        public string ManufacturerName { get; set; }
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressure { get; set; }

        public void InflateTire(float i_AirPressureAddup)
        {
            validateAirPressure(i_AirPressureAddup);
            CurrentAirPressure += i_AirPressureAddup;
        }

        public void InflateToMaxPressure()
        {
            InflateTire(MaxAirPressure - CurrentAirPressure);
        }

        private void validateAirPressure(float i_AirPressure)
        {
            if (i_AirPressure <= 0)
            {
                throw new ArgumentException("Cannot add a non-positive amount of air!");
            }

            else if (i_AirPressure + CurrentAirPressure > MaxAirPressure)
            {
                throw new ArgumentException($"Denied: Wheel has already {CurrentAirPressure} psi " +
                    $"of air pressure.\nInflating {i_AirPressure} psi is out of manufacturor's recommendation!");
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Wheel manufacturor: {ManufacturerName}");
            stringBuilder.AppendLine($"Wheel current air pressure: {CurrentAirPressure} psi");
            stringBuilder.AppendLine($"Wheel maximum air pressure: {MaxAirPressure} psi");

            return stringBuilder.ToString();
        }
    }
}