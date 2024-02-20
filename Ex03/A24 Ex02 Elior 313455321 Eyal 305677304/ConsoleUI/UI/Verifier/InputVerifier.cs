using ConsoleUI.UI.Enums;

namespace ConsoleUI.UI.Verifier
{
    internal class InputVerifier
    {
        public bool VerifyActionChoice(string i_Input, out eUserOptions o_Choice)
        {
            bool parseable = int.TryParse(i_Input, out int choice);

            o_Choice = (eUserOptions)choice;

            return parseable && choice >= (int)eUserOptions.InsertVehicle
                && choice <= (int)eUserOptions.Exit;
        }
    }
}