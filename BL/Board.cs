using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BL
{
    public class Board
    {
        public bool[,] PlayerBoard { get; set; }
        public Board()
        {
            PlayerBoard = new bool[(int.Parse(AccessConfiguration.BoardSize)), (int.Parse(AccessConfiguration.BoardSize))];
            for(int i = 0;i < (int.Parse(AccessConfiguration.BoardSize));i++)
            {
                for(int j = 0;j < (int.Parse(AccessConfiguration.BoardSize));j++)
                {
                    PlayerBoard[i, j] = false;
                }
            }
        }
    }
}
