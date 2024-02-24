using System;
using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.Car
{
    public class CarInfo
    {
        public eCarColors Color { get; set; }
        public eCarDoors NumOfDoors { get; set; }

        public static eCarColors ValidateCarColor(string i_ColorChoice)
        {
            eCarColors color;

            if (!Enum.IsDefined(typeof(eCarColors), i_ColorChoice))
            {
                throw new ArgumentException("Invalid car color!");
            }

            else
            {
                Enum.TryParse(i_ColorChoice, out color);
            }

            return color;
        }

        public static eCarDoors ValidateNumOfDoors(uint i_DoorsChoice)
        {
            if (!Enum.IsDefined(typeof(eCarDoors), i_DoorsChoice))
            {
                throw new ArgumentException("Invalid number of doors!");
            }

            else
            {
                return (eCarDoors)i_DoorsChoice;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Car color: {Color}");
            stringBuilder.AppendLine($"Car doors: {(uint)NumOfDoors}");

            return stringBuilder.ToString();
        }
    }
}