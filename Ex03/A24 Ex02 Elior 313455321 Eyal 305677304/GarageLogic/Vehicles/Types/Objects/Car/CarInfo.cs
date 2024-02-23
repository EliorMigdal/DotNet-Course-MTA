using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.Car
{
    public class CarInfo
    {
        public eCarColors Color { get; set; }
        public eCarDoors NumOfDoors { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Car color: {Color}");
            stringBuilder.AppendLine($"Car doors: {(int)NumOfDoors}");

            return stringBuilder.ToString();
        }
    }
}