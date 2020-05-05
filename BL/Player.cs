using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Player
    {
        public int PlayerId { get; set; }
        public Board PlayerBoard { get; set; }
        public Board PlayerDefendBoard { get; set; }
        private static Random _randomId = new Random();
        public Player()
        {
            PlayerId = _randomId.Next(1000,999999999);
            PlayerBoard = new Board();
            PlayerDefendBoard = new Board();
        }
        public void CopyToDefenceBoard()
        {
            
            for (int i = 0; i < int.Parse(AccessConfiguration.BoardSize); i++)
            {
                for (int j = 0; j < int.Parse(AccessConfiguration.BoardSize); j++)
                {
                    PlayerDefendBoard.PlayerBoard[i, j] = PlayerBoard.PlayerBoard[i, j];
                }
            }
        }
    }
}
