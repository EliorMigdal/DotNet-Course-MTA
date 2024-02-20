namespace GarageLogic.Vehicles
{
    internal class Wheel
    {
        public string ManufacturerName { get; set; }
        public float CurrentAirPressure { get; set; }
        private readonly float r_MaxAirPressure;

        public Wheel (float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }

        public void InflateTire(float i_AirPressureAddup)
        {
            
        }

        public void InflateToMaxPressure()
        {
            InflateTire(r_MaxAirPressure - CurrentAirPressure);
        }
    }
}