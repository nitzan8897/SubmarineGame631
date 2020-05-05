using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Submarine
    {
        public int Length { get; set; }
        public Point SubmarineStartPoint { get; set; }
        public Point SubmarineEndPoint { get; set; }
        public Submarine(int length)
        {
            Length = length;
        }
        // Should be executed after submarine placement.
        // after all placements CopyBoard Function to the defend board.
        private bool IsValidSubmarineAxisPlacement()
        {
            if(SubmarineStartPoint.X != SubmarineEndPoint.X && SubmarineStartPoint.Y != SubmarineEndPoint.Y)
            {
                return false;
            }
            return true;
        }
        private bool IsValidEdges(Board gameBoard)
        {
            if(SubmarineStartPoint.X < 0 && SubmarineStartPoint.Y < 0)
            {
                return false;
            }
            if (SubmarineEndPoint.X < 0 && SubmarineEndPoint.Y < 0)
            {
                return false;
            }
            if (SubmarineStartPoint.X > gameBoard.PlayerBoard.GetLength(1) && SubmarineStartPoint.Y > gameBoard.PlayerBoard.GetLength(0))
            {
                return false;
            }
            if (SubmarineEndPoint.X > gameBoard.PlayerBoard.GetLength(1) && SubmarineEndPoint.Y > gameBoard.PlayerBoard.GetLength(0))
            {
                return false;
            }
            return true;
        }
        private bool IsSubmarineAlreadyPlaced(Board gameBoard)
        {
            bool found = false;
            //still adding to place marine.
            //still Y not working.
            if(SubmarineStartPoint.X != SubmarineEndPoint.X)
            {
                if(SubmarineStartPoint.X < SubmarineEndPoint.X)
                {
                    for (int i = SubmarineStartPoint.X; i <= SubmarineEndPoint.X; i++)
                    {
                        found = !gameBoard.PlayerBoard[i, SubmarineStartPoint.Y];
                    }
                }
                if (SubmarineStartPoint.X > SubmarineEndPoint.X)
                {
                    for (int i = SubmarineStartPoint.X; i >= SubmarineEndPoint.X; i--)
                    {
                        found = !gameBoard.PlayerBoard[i, SubmarineStartPoint.Y];
                    }
                }

            }
            if (SubmarineStartPoint.Y != SubmarineEndPoint.Y)
            {
                if (SubmarineStartPoint.Y < SubmarineEndPoint.Y)
                {
                    for (int i = SubmarineStartPoint.Y; i <= SubmarineEndPoint.Y; i++)
                    {
                        found = !gameBoard.PlayerBoard[SubmarineStartPoint.X, i];
                    }
                }
                if (SubmarineStartPoint.Y > SubmarineEndPoint.Y)
                {
                    for (int i = SubmarineStartPoint.Y; i >= SubmarineEndPoint.Y; i--)
                    {
                        found = !gameBoard.PlayerBoard[SubmarineStartPoint.X, i];
                    }
                }
               
            }
            return found;
        }

        public bool IsValidSubmarineLength()
        {
            if (SubmarineStartPoint.X != SubmarineEndPoint.X)
            {
                if(SubmarineStartPoint.X > SubmarineEndPoint.X)
                {
                    return Length == (SubmarineStartPoint.X - SubmarineEndPoint.X )+1;
                }
                if (SubmarineStartPoint.X < SubmarineEndPoint.X)
                {
                    return Length == (SubmarineEndPoint.X - SubmarineStartPoint.X)+1;
                }
            }
            if (SubmarineStartPoint.Y != SubmarineEndPoint.Y)
            {
                if (SubmarineStartPoint.Y > SubmarineEndPoint.Y)
                {
                    return Length == (SubmarineStartPoint.Y - SubmarineEndPoint.Y)+1;
                }
                if (SubmarineStartPoint.Y < SubmarineEndPoint.Y)
                {
                    return Length == (SubmarineEndPoint.Y - SubmarineStartPoint.Y)+1;
                }
            }
            return false;
        }
        public bool ValidateSubmarinePlacement(Board gameBoard)
        {
            return  IsValidEdges(gameBoard) && IsValidSubmarineAxisPlacement()&& IsValidSubmarineLength() && IsSubmarineAlreadyPlaced(gameBoard);
            //after that function should come the application of the placement on board.
        }

        public Board PlaceSubmarine(Board boardToPlace)
        {
            if (SubmarineStartPoint.X != SubmarineEndPoint.X)
            {
                if (SubmarineStartPoint.X < SubmarineEndPoint.X)
                {
                    for (int i = SubmarineStartPoint.X; i <= SubmarineEndPoint.X; i++)
                    {
                        boardToPlace.PlayerBoard[i, SubmarineStartPoint.Y] = true;
                    }
                }
                if (SubmarineStartPoint.X > SubmarineEndPoint.X)
                {
                    for (int i = SubmarineStartPoint.X; i >= SubmarineEndPoint.X; i--)
                    {
                        boardToPlace.PlayerBoard[i, SubmarineStartPoint.Y] = true;
                    }
                }
            }
            if (SubmarineStartPoint.Y != SubmarineEndPoint.Y)
            {
                if (SubmarineStartPoint.Y < SubmarineEndPoint.Y)
                {
                    for (int i = SubmarineStartPoint.Y; i <= SubmarineEndPoint.Y; i++)
                    {
                        boardToPlace.PlayerBoard[SubmarineStartPoint.X, i] = true;
                    }
                }
                if (SubmarineStartPoint.Y > SubmarineEndPoint.Y)
                {
                    for (int i = SubmarineStartPoint.Y; i >= SubmarineEndPoint.Y; i--)
                    {
                        boardToPlace.PlayerBoard[SubmarineStartPoint.X, i] = true;
                    }
                }
            }
            return boardToPlace;
        }
    }
}
