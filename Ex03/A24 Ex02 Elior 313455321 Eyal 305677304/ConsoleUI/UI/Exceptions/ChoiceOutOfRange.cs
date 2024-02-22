using System;

namespace ConsoleUI.UI.Exceptions
{
    internal class ChoiceOutOfRangeException : Exception
    {
        public int MinValue { get; set; }
        public int MaxValue { get; set; }

        public ChoiceOutOfRangeException(int i_MinValue, int i_MaxValue)
            : base($"Value is outside the allowed range. Min: {i_MinValue}, Max: {i_MaxValue}")
        {
            MinValue = i_MinValue;
            MaxValue = i_MaxValue;
        }
    }
}