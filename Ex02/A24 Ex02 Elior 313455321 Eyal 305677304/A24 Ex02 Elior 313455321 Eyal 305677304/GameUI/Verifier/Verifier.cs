public class Verifier
{
    public bool VerifyBoardSize(string i_Width, string i_Height, ref GameInfo o_GameInfo)
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

    private bool isInRange(int i_Value)
    {
        return i_Value.CompareTo(eDimensions.MinValue) >= 0 && i_Value.CompareTo(eDimensions.MaxValue) <= 0;
    }

    public bool VerifyParticipantsChoice(string i_Choice, ref GameInfo o_GameInfo) 
    {
        bool isANumber = int.TryParse(i_Choice, out int choice);
        bool isChoiceValid = isANumber && (choice.Equals(eUserChoice.PLAY_AI) || choice.Equals(eUserChoice.PLAY_PLAYER));

        if (isChoiceValid)
        {
            o_GameInfo.PlayTheAI = choice.Equals(eUserChoice.PLAY_AI);
        }

        return isChoiceValid;
    }
}
