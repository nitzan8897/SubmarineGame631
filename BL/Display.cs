using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Display : IIODisplay
    {
        public Display()
        {

        }

        public void ClearChat()
        {
            Console.Clear();
        }

        public void Print(string textToPrint)
        {
            throw new NotImplementedException();
        }

        public void PrintEnterXAttackPoint()
        {
            Console.WriteLine("Enter X point to attack : ");
        }

        public void PrintEnterYAttackPoint()
        {
            Console.WriteLine("Enter Y point to attack : ");
        }

        public void PrintFailedAttack()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("And you hit WATER. Later looser.");
            Console.ResetColor();
        }

        public void PrintFailedSetupSubmarine()
        {
            Console.WriteLine("Submarine Is not valid and could not be added.");
        }

        public void PrintNotValidAttack()
        {
            Console.WriteLine("Attack Cordinates not valid , try again.");
        }

        public void PrintPlayerTurn(int playerId)
        {
            Console.WriteLine("Player :"+playerId+"'s turn to play!");
        }

        public void PrintSuccessfulAttack()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("BOOM! You hit a Submarine Good job!");
            Console.ResetColor();
        }

        public void PrintSuccessfulSetupSubmarine()
        {
            Console.WriteLine("Successfuly added submarine.");
        }

        public void PrintWelcomeToGame(Player playerToWelcome)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hi player : " + playerToWelcome.PlayerId + " \n Welcome to Submarine Game 631");
            Console.ResetColor();
        }

        public void PrintXEndPointSetup(int submarineLength)
        {
            Console.WriteLine("Enter X End position for " + submarineLength + " Length Submarine");
        }

        public void PrintXStartPointSetup(int submarineLength)
        {
            Console.WriteLine("Enter X Start position for " + submarineLength + " Length Submarine");
        }

        public void PrintYEndPointSetup(int submarineLength)
        {
            Console.WriteLine("Enter Y End position for " + submarineLength + " Length Submarine");
        }

        public void PrintYStartPointSetup(int submarineLength)
        {
            Console.WriteLine("Enter Y Start position for " + submarineLength + " Length Submarine");
        }

        public string Read()
        {
            string Red = Console.ReadLine();
            return Red;
        }
    }
}
