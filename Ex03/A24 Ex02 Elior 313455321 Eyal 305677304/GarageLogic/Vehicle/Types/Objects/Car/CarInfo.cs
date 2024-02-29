using System;
using System.Text;

namespace GarageLogic.Vehicles.Types.Objects.Car
{
    public class CarInfo : VehicleInfo
    {
        public enum eCarColors
        {
            Blue,
            White,
            Red,
            Yellow
        }

        public enum eCarDoors : uint
        {
            TwoDoor = 2,
            ThreeDoor = 3,
            FourDoor = 4,
            FiveDoor = 5
        }

        public eCarColors Color { get; private set; }
        public eCarDoors NumOfDoors { get; private set; }

        public void SetCarColor(string i_ColorInput)
        {
            Color = validateCarColor(i_ColorInput);
        }

        public void SetNumOfDoors(uint i_NumOfDoors)
        {
            NumOfDoors = validateNumOfDoors(i_NumOfDoors);
        }

        private eCarColors validateCarColor(string i_ColorChoice)
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

        private eCarDoors validateNumOfDoors(uint i_DoorsChoice)
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

            stringBuilder.Append(base.ToString());
            stringBuilder.AppendLine($"Car color: {Color}");
            stringBuilder.AppendLine($"Car doors: {(uint)NumOfDoors}");

            return stringBuilder.ToString();
        }
    }
}