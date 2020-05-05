using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    interface IIODisplay
    {
        string Read();
        void Print(string textToPrint);
        void PrintXStartPointSetup(int submarineLength);

        void PrintYStartPointSetup(int submarineLength);

        void PrintXEndPointSetup(int submarineLength);

        void PrintYEndPointSetup(int submarineLength);
        
        void PrintSuccessfulSetupSubmarine();

        void PrintFailedSetupSubmarine();

        void PrintWelcomeToGame(Player playerToWelcome);

        void PrintNotValidAttack();

        void PrintSuccessfulAttack();

        void PrintFailedAttack();

        void PrintEnterXAttackPoint();

        void PrintEnterYAttackPoint();

        void PrintPlayerTurn(int playerId);

        void ClearChat();
    }
}
