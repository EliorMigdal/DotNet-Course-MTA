using ConsoleUI.UI.Enums;
using System;

namespace ConsoleUI.UI.Validator
{
    internal class InputValidator
    {
        public void ValidateActionChoice(string i_Input, out eUserOptions o_Choice)
        {
            TryParsingToUnsignedInt(i_Input, out uint choice);
            o_Choice = validateUserChoice(choice);
        }

        public void ValidateDangerousLuggageInput(string i_Input, out bool o_HasDangerousLuggage)
        {
            if (!i_Input.Equals("Y") && !i_Input.Equals("N"))
            {
                throw new ArgumentException("Invalid choice!");
            }

            o_HasDangerousLuggage = i_Input.Equals("Y");
        }

        public void TryParsingToUnsignedInt(string i_Input, out uint o_Parsed)
        {
            bool parsable = uint.TryParse(i_Input, out o_Parsed);

            if (!parsable)
            {
                throw new FormatException($"{i_Input} cannot be parsed to a positive integer!");
            }
        }

        public void TryParsingToFloat(string i_Input, out float o_Parsed)
        {
            bool parsable = float.TryParse(i_Input, out o_Parsed);

            if (!parsable)
            {
                throw new FormatException($"{i_Input} cannot be parsed to a float!");
            }
        }

        private eUserOptions validateUserChoice(uint i_Choice)
        {
            if (!Enum.IsDefined(typeof(eUserOptions), i_Choice))
            {
                throw new ArgumentException("Invalid user choice!");
            }

            else
            {
                return (eUserOptions)i_Choice;
            }
        }
    }
}