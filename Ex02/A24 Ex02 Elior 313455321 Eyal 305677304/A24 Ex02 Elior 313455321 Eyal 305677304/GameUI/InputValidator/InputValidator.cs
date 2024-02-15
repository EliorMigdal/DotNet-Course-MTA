public class InputValidator
{
    public bool ValidateBoardSize(string i_Width, string i_Height, ref GameInfo o_GameInfo)
    {
        bool isWidthValid = int.TryParse(i_Width, out int width);
        bool isHeightValid = int.TryParse(i_Height, out int height);

        bool isSizeValid = isWidthValid && isHeightValid && isInRange(width) && isInRange(height);

        if (isSizeValid)
        {
            o_GameInfo.Width = width; 
            o_GameInfo.Height = height;
        }

        return isSizeValid;
    }

    public bool isInRange(int i_Value)
    {
        return i_Value.CompareTo((int) eDimensions.MinValue) >= 0 
            && i_Value.CompareTo((int) eDimensions.MaxValue) <= 0;
    }

    public bool ValidateParticipantsChoice(string i_Choice, ref GameInfo o_GameInfo) 
    {
        bool isANumber = int.TryParse(i_Choice, out int choice);
        bool isChoiceValid = isANumber && (choice.Equals((int) eUserChoice.PlayAI) 
            || choice.Equals((int) eUserChoice.PlayAnotherPlayer));

        if (isChoiceValid)
        {
            o_GameInfo.PlayTheAI = choice.Equals((int) eUserChoice.PlayAI);
        }

        return isChoiceValid;
    }

    public bool ValidateMoveInput(string i_MoveChoice, out int o_ColumnNum)
    {
        return int.TryParse(i_MoveChoice, out o_ColumnNum) || i_MoveChoice.Equals("Q");
    }

    public bool ValidateRoundInput(string i_RoundChoice, out bool o_RoundChoice)
    {
        bool isInputValid = i_RoundChoice.Equals("Y") || i_RoundChoice.Equals("N");

        if (isInputValid)
        {
            o_RoundChoice = i_RoundChoice.Equals("Y") ? true : false;
        }

        else
        {
            o_RoundChoice = false;
        }

        return isInputValid;
    }
}
