public class GameParticipant
{
    public string Name { get; set; }
    public bool IsAI { get; set; }
    public int Score { get; set; }

    public GameParticipant(string i_Name, bool i_IsAI)
    {
        Name = i_Name;
        IsAI = i_IsAI;
        Score = 0;
    }

    public void AddPoint()
    {
        Score++;
    }
}