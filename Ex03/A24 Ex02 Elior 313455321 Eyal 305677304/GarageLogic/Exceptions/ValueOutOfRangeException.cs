using System;

namespace GarageLogic.Exceptions
{
    public class ValueOutOfRangeException : Exception
    {
        public float MinValue { get; set; }
        public float MaxValue { get; set; }

        public ValueOutOfRangeException(string i_ParamName, float i_MinValue, float i_MaxValue)
            : base($"{i_ParamName} is outside the allowed range. Min: {i_MinValue:F2}, Max: {i_MaxValue:F2}")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}