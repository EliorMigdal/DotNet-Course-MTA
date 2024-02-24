using GarageLogic.Exceptions;
using System.Text;

namespace GarageLogic.Vehicles
{
    public class Wheel
    {
        public string ManufacturerName { get; set; }
        private float m_CurrentAirPressure;
        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }

            set
            {
                if (value > MaxAirPressure || value < 0f)
                {
                    throw new ValueOutOfRangeException("Air Pressure", 0f, MaxAirPressure);
                }

                m_CurrentAirPressure = value;
            }
        }
        public float MaxAirPressure { get; set; }

        public void InflateTire(float i_AirPressureAddup)
        {
            CurrentAirPressure += i_AirPressureAddup;
        }

        public void InflateToMaxPressure()
        {
            InflateTire(MaxAirPressure - CurrentAirPressure);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Wheel manufacturor:{ManufacturerName}");
            stringBuilder.AppendLine($"Wheel current air pressure:{CurrentAirPressure} psi");
            stringBuilder.AppendLine($"Wheel maximum air pressure:{MaxAirPressure} psi");

            return stringBuilder.ToString();
        }
    }
}