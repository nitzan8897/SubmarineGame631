using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Game
    {
        public List<Player> GamePlayers;
        public Game(List<Player>gamePlayers)
        {
            GamePlayers = new List<Player>();
            gamePlayers.ForEach(player => GamePlayers.Add(player));
        }
        public Board AttackUpdateBoard(Player Defender,Point pointToAttack)
        {
            if(Defender.PlayerDefendBoard.PlayerBoard[pointToAttack.X,pointToAttack.Y])
            {
                Defender.PlayerDefendBoard.PlayerBoard[pointToAttack.X, pointToAttack.Y] = false;
            }
            return Defender.PlayerDefendBoard;
        }

        private bool CheckPossibleWinner(Board firstBoard,Board secondBoard)
        {
            bool firstStatus = false;
            bool secondStatus = false;
            for (int i = 0; i < firstBoard.PlayerBoard.GetLength(0); i++)
            {
                for (int j = 0; j < firstBoard.PlayerBoard.GetLength(1); j++)
                {
                    firstStatus = firstBoard.PlayerBoard[i, j];
                    if (firstBoard.PlayerBoard[i, j])
                    {
                        return false;
                    }
                }
            }
            for (int i = 0; i < secondBoard.PlayerBoard.GetLength(0); i++)
            {
                for (int j = 0; j < secondBoard.PlayerBoard.GetLength(1); j++)
                {
                    secondStatus = secondBoard.PlayerBoard[i, j];
                    if(secondBoard.PlayerBoard[i,j])
                    {
                        return false;
                    }
                }
            }
            return !firstStatus || !secondStatus;
        }

        public Board Winner(Board firstBoard , Board secondBoard)
        {
            bool checkWinner = false;
            if (CheckPossibleWinner(firstBoard, secondBoard))
            {
                for (int i = 0; i < firstBoard.PlayerBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < firstBoard.PlayerBoard.GetLength(1); j++)
                    {
                        checkWinner = firstBoard.PlayerBoard[i, j];
                        if(checkWinner)
                        {
                            break;
                        }
                    }
                }
                if(!checkWinner)
                {
                    return firstBoard;
                }
                return secondBoard;
            }
            return null;
        }

    }
}
