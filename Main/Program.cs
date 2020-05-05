using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;


namespace UI
{
    class Program
    {
        public static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            Player player1 = new Player();
            Player player2 = new Player();
            gm.GameManagment.GamePlayers.Add(player1);
            gm.GameManagment.GamePlayers.Add(player2);
            gm.StartGame(player1.PlayerId, player2.PlayerId);
        }
    }
}
