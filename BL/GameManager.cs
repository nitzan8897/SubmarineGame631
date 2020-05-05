using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace BL
{
    public class GameManager
    {
        public Game GameManagment { get; set; }
        public Display GameDisplayer { get; set; }
        public GameManager()
        {
            List<Player> players = new List<Player>();
            GameManagment = new Game(players);
            GameDisplayer = new Display();
        }
        private Board GetBoardByPlayerId(int playerId)
        {
            return GameManagment.GamePlayers.Where(player => player.PlayerId == playerId).FirstOrDefault().PlayerBoard;
        }
        private Player GetPlayerById(int playerId)
        {
            return GameManagment.GamePlayers.Where(player => player.PlayerId == playerId).FirstOrDefault();
        }
        private void SubmarineSetup(int playerId)
        {
            string X, Y;
            Submarine submarineToAttach;
            for (int i = 0 ; i < int.Parse(AccessConfiguration.SubmarinesNumber) ; i++)
            {
                    GameDisplayer.PrintXStartPointSetup(int.Parse(AccessConfiguration.SubmarinesLengths[i]));
                    X = GameDisplayer.Read();
                    GameDisplayer.PrintYStartPointSetup(int.Parse(AccessConfiguration.SubmarinesLengths[i]));
                    Y = GameDisplayer.Read();
                    submarineToAttach = new Submarine(int.Parse(AccessConfiguration.SubmarinesLengths[i]));
                    submarineToAttach.SubmarineStartPoint = new Point(int.Parse(X)-1, int.Parse(Y)-1);
                    GameDisplayer.PrintXEndPointSetup(int.Parse(AccessConfiguration.SubmarinesLengths[i]));
                    X = GameDisplayer.Read();
                    GameDisplayer.PrintYEndPointSetup(int.Parse(AccessConfiguration.SubmarinesLengths[i]));
                    Y = GameDisplayer.Read();
                    submarineToAttach.SubmarineEndPoint = new Point(int.Parse(X)-1, int.Parse(Y)-1);
                if(submarineToAttach.ValidateSubmarinePlacement(GetBoardByPlayerId(playerId)))
                {
                    GetBoardByPlayerId(playerId).PlayerBoard = submarineToAttach.PlaceSubmarine(GetBoardByPlayerId(playerId)).PlayerBoard;
                    GetPlayerById(playerId).CopyToDefenceBoard();
                    GameDisplayer.PrintSuccessfulSetupSubmarine();
                }

                else
                {
                    GameDisplayer.PrintFailedSetupSubmarine();
                    i--;
                }
            }

        }
        public bool Attack(int targetId)
        {
            string X, Y;
            GameDisplayer.PrintEnterXAttackPoint();
            X = GameDisplayer.Read();
            GameDisplayer.PrintEnterYAttackPoint();
            Y = GameDisplayer.Read();
            Point pointToAttack = new Point(int.Parse(X)-1, int.Parse(Y)-1);
            if (GetBoardByPlayerId(targetId).PlayerBoard[pointToAttack.X,pointToAttack.Y])
            {
                GameManagment.AttackUpdateBoard(GetPlayerById(targetId), pointToAttack);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StartGame(int playerOneId, int playerTwoId)
        {
            GameDisplayer.PrintWelcomeToGame(GetPlayerById(playerOneId));
            GameDisplayer.PrintWelcomeToGame(GetPlayerById(playerTwoId));
            SubmarineSetup(playerOneId);
            GameDisplayer.ClearChat();
            GameDisplayer.PrintWelcomeToGame(GetPlayerById(playerTwoId));
            SubmarineSetup(playerTwoId);
            GameDisplayer.ClearChat();
            while (GetWinner(playerOneId, playerTwoId) == 0)
            {
                QueueManager(playerOneId, playerTwoId);
            }
            
        }

        private int GetWinner(int firstPlayerId,int secondPlayerId)
        {
            if (GameManagment.Winner(GetBoardByPlayerId(firstPlayerId), GetBoardByPlayerId(secondPlayerId)) != null)
            {
                if (GameManagment.Winner(GetBoardByPlayerId(firstPlayerId), GetBoardByPlayerId(secondPlayerId)) == GetBoardByPlayerId(firstPlayerId))
                {
                    return firstPlayerId;
                }
                if (GameManagment.Winner(GetBoardByPlayerId(firstPlayerId), GetBoardByPlayerId(secondPlayerId)) == GetBoardByPlayerId(secondPlayerId))
                {
                    return secondPlayerId;
                }
                
            }
            return 0;
        }

        private void QueueManager(int firstPlayerId, int secondPlayerId)
        {
            GameDisplayer.PrintPlayerTurn(firstPlayerId);
            while(Attack(secondPlayerId))
            {
                GameDisplayer.PrintSuccessfulAttack();
                GameDisplayer.PrintPlayerTurn(firstPlayerId);
            }
            GameDisplayer.PrintFailedAttack();
            GameDisplayer.PrintPlayerTurn(secondPlayerId);
            while (Attack(firstPlayerId))
            {
                GameDisplayer.PrintSuccessfulAttack();
                GameDisplayer.PrintPlayerTurn(secondPlayerId);
            }
            GameDisplayer.PrintFailedAttack();
        }
    }
}
