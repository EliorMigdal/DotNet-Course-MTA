namespace GarageLogic.Vehicles
{
    public class Wheel
    {
        public string ManufacturerName { get; set; }
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressure { get; set; }

        public void InflateTire(float i_AirPressureAddup)
        {
            
        }

        public void InflateToMaxPressure()
        {
            InflateTire(MaxAirPressure - CurrentAirPressure);
        }
    }
}