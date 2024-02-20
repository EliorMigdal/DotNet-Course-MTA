using ConsoleUI.UI.Enums;
using ConsoleUI.UI.Printer;
using ConsoleUI.UI.Reader;
using ConsoleUI.UI.Verifier;

namespace ConsoleUI.UI
{
    internal class GarageUI
    {
        private readonly OutputPrinter r_OutputPrinter = new OutputPrinter();
        private readonly InputReader r_InputReader = new InputReader();
        private readonly InputVerifier r_Verifier = new InputVerifier();

        public void RunSystem()
        {
            bool hasUserExited = false;
            string userInput;
            eUserOptions userChoice;

            r_OutputPrinter.GreetUser();
            
            while (!hasUserExited)
            {
                userInput = handleActionChoice();

                while (!r_Verifier.VerifyActionChoice(userInput, out userChoice))
                {
                    r_OutputPrinter.PrintError("Invalid action choice! Please try again.");
                    userInput = handleActionChoice();
                }

                ExecuteUserAction(userChoice);
                hasUserExited = userChoice.Equals(eUserOptions.Exit);
            }
        }

        private string handleActionChoice()
        {
            r_OutputPrinter.PrintUserOptions();
            return r_InputReader.ReadUserChoice();
        }

        public void ExecuteUserAction(eUserOptions i_UserChoice)
        {
            switch (i_UserChoice)
            {
                case eUserOptions.InsertVehicle:
                    insertNewVehicle();
                    break;

                case eUserOptions.DisplayLicenses:
                    displayLicenses();
                    break;

                case eUserOptions.UpdateVehicleState:
                    updateVehicleState();
                    break;

                case eUserOptions.InflateVehicleTires:
                    inflateVehicleTires();
                    break;

                case eUserOptions.FillGas:
                    fillGas();
                    break;

                case eUserOptions.ChargeBattery:
                    chargeBattery();
                    break;

                case eUserOptions.DisplayVehicleInfo:
                    displayVehicleInfo();
                    break;

                case eUserOptions.Exit:
                    break;

                default:
                    break;
            }
        }

        private void insertNewVehicle()
        {

        }

        private void displayLicenses()
        {

        }

        private void updateVehicleState()
        {

        }

        private void inflateVehicleTires()
        {

        }

        private void fillGas()
        {

        }

        private void chargeBattery()
        {

        }

        private void displayVehicleInfo()
        {

        }
    }
}