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
        public GameBoard GameBoard { get; set; } = new GameBoard();
        public List<GameParticipant> GameParticipants { get; set; }
        public RoundResult RoundResult { get; set; } = new RoundResult();
        private readonly BoardInspector r_BoardInspector = new BoardInspector();
        private GameParticipant m_CurrentPlayer = null;

        public void InitializeEngine(GameInfo i_GameInfo)
        {
            GameBoard.InitializeBoard(i_GameInfo.Height, i_GameInfo.Width);

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

            else
            {
                updateTurn();
            }

            return isThereAWinner || isThereADraw || hasPlayerForfieted();
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
            bool isValid = true;

            if (!hasPlayerForfieted())
            {
                isValid = i_ColumnNum - 1 >= 0 && i_ColumnNum - 1 <= GameBoard.GetBoardWidth() - 1 &&
                    GameBoard.IsThereAFreeSpaceInColumn(i_ColumnNum - 1);
            }

            return isValid;
        }

        public void ForfietPlayer()
        {
            updateTurn();
            handleWinner();
        }

        public void ResetEngineData()
        {
            GameBoard.EmptyAllCells();
            m_CurrentPlayer = GameParticipants[0];
            RoundResult.RoundWinner = string.Empty;
        }

        public void InsertCoin(int i_Column)
        {
            if (!hasPlayerForfieted())
            {
                char coinSymbol = m_CurrentPlayer.Symbol;

                GameBoard.InsertToAColumn(i_Column, coinSymbol);
            }
        }

        private void updateTurn()
        {
            int i = GameParticipants.FindIndex(p => p.Equals(m_CurrentPlayer));

            m_CurrentPlayer = GameParticipants[(i + 1) % GameParticipants.Count];
        }

        public void MakeAIMove()
        {
            int column;

            do
            {
                column = new Random().Next(0, GameBoard.GetBoardWidth());
            } while (!GameBoard.IsThereAFreeSpaceInColumn(column));

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

        public bool ValidateBoardSize(int i_Width, int i_Height)
        {
            return GameBoard.IsSizeValid(i_Width, i_Height);
        }

        public void GetBoardDimensions(out int o_MinDimension, out int o_MaxDimension)
        {
            GameBoard.GetDimensions(out o_MinDimension, out o_MaxDimension);
        }

        private bool hasPlayerForfieted()
        {
            return !RoundResult.RoundWinner.Equals(string.Empty);
        }
    }
}