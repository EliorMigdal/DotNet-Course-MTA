namespace FourInARow.Engine.Participant
{
    public class GameParticipant
    {
        public string Name { get; set; }
        public bool IsAI { get; set; }
        public int Score { get; set; }
        public char Symbol { get; set; }

        public GameParticipant(string i_Name, bool i_IsAI, char symbol)
        {
            Name = i_Name;
            IsAI = i_IsAI;
            Score = 0;
            Symbol = symbol;
        }

        public void AddPoint()
        {
            Score++;
        }
    }
}