using FourInARow.Engine.Board;
using FourInARow.Engine.Inspector;
using FourInARow.Engine.Participant;
using System;
using System.Collections.Generic;
using FourInARow.DTO;

namespace FourInARow.Engine
{
    public class GameEngine
    {
        public GameBoard GameBoard { get; set; }
        public List<GameParticipant> GameParticipants { get; set; }
        public RoundResult RoundResult { get; set; }
        private readonly BoardInspector r_BoardInspector = new BoardInspector();
        private GameParticipant m_CurrentPlayer = null;

        public void InitializeEngine(GameInfo i_GameInfo)
        {
            GameBoard = new GameBoard(i_GameInfo.Height, i_GameInfo.Width);
            RoundResult = new RoundResult();

            GameParticipants = new List<GameParticipant>
        {
            new GameParticipant("P1", false, 'O')
        };

            if (i_GameInfo.PlayTheAI)
            {
                GameParticipants.Add(new GameParticipant("AI", true, 'X'));
            }

            else
            {
                GameParticipants.Add(new GameParticipant("P2", false, 'X'));
            }

            m_CurrentPlayer = GameParticipants[0];
            RoundResult.RoundWinner = string.Empty;
        }

        public bool HasGameConcluded()
        {
            bool isThereAWinner = r_BoardInspector.IsThereAWinner(GameBoard);
            bool isThereADraw = r_BoardInspector.IsThereADraw(GameBoard);

            if (isThereAWinner)
            {
                handleWinner();
            }

            else if (isThereADraw)
            {
                handleDraw();
            }

            else if (!hasGameJustStarted())
            {
                updateTurn();
            }

            return isThereAWinner || isThereADraw || !RoundResult.RoundWinner.Equals(string.Empty);
        }

        private bool hasGameJustStarted()
        {
            return GameBoard.GetSymbol(GameBoard.LatestPointInserted).Equals(' ');
        }

        public string GetNextPlayersName()
        {
            return m_CurrentPlayer.Name;
        }

        public bool IsItAITurn()
        {
            return m_CurrentPlayer.IsAI;
        }

        public bool ValidateMoveLogic(int i_ColumnNum)
        {
            bool isValid = i_ColumnNum >= 0 && i_ColumnNum <= GameBoard.GetBoardWidth() - 1;

            return isValid && GameBoard.IsThereAFreeSpaceInColumn(i_ColumnNum);
        }

        public void ForfietPlayer()
        {
            updateTurn();
            handleWinner();
        }

        public void ResetEngineData()
        {
            GameBoard.InitializeBoard();
            m_CurrentPlayer = GameParticipants[0];
            RoundResult.RoundWinner = string.Empty;
        }

        public void InsertCoin(int i_Column)
        {
            char coinSymbol = m_CurrentPlayer.Symbol;

            GameBoard.InsertToAColumn(i_Column, coinSymbol);
        }

        private void updateTurn()
        {
            int i = GameParticipants.FindIndex(p => p.Equals(m_CurrentPlayer));

            m_CurrentPlayer = GameParticipants[(i + 1) % GameParticipants.Count];
        }

        public void MakeAIMove()
        {
            int column = new Random().Next(0, GameBoard.GetBoardWidth());

            while (!GameBoard.IsThereAFreeSpaceInColumn(column))
            {
                column = new Random().Next(0, GameBoard.GetBoardWidth());
            }

            InsertCoin(column);
        }

        private void handleWinner()
        {
            m_CurrentPlayer.Score++;
            RoundResult.RoundWinner = m_CurrentPlayer.Name;
            RoundResult.RoundOutcome = eRoundOutcome.Conclusion;
        }

        private void handleDraw()
        {
            RoundResult.RoundWinner = string.Empty;
            RoundResult.RoundOutcome = eRoundOutcome.Draw;
        }
    }
}