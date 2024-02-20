using System;

namespace GarageLogic.Exceptions
{
    internal class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
            : base($"Value is outside the allowed range. Min: {i_MinValue}, Max: {i_MaxValue}")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}