using MarsRover.Enums;
using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Rover : IRover
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Orientation { get; private set; }
        public Plateau Plateau { get; }


        public Rover(int x, int y, Direction orientation, Plateau plateau)
        {
            Plateau = plateau;
            if (!Plateau.CanMove(x, y))
            {
                // This shouldn't be hard codded message, should be custom Exception type
                throw new Exception("Hey rover where are you going");
            }

            X = x;
            Y = y;
            Orientation = orientation;
        }


        public void Execute(IList<Command> commands)
        {
            foreach (Command command in commands)
            {
                switch (command)
                {
                    case Command.GoForward:

                        if (Orientation == Direction.North)
                            Y++;
                        else if (Orientation == Direction.East)
                            X++;
                        else if (Orientation == Direction.South)
                            Y--;
                        else
                            X--;

                        break;
                    case Command.TurnLeft:

                        if ((int)Orientation == 0)
                            Orientation = (Direction)3;
                        else
                            Orientation = (Direction)((int)Orientation - 1);

                        break;
                    case Command.TurnRight:

                        if ((int)Orientation == 3)
                            Orientation = (Direction)0;
                        else
                            Orientation = (Direction)((int)Orientation + 1);

                        break;
                }
            }
        }

        //private void GoForward()
        //{
        //    var tempX = this.X;
        //    var tempY = this.Y;

        //    switch (Orientation)
        //    {
        //        case Direction.North:
        //            tempY += 1;
        //            break;
        //        case Direction.East:
        //            tempX += 1;
        //            break;
        //        case Direction.South:
        //            tempY -= 1;
        //            break;
        //        case Direction.West:
        //            tempX -= 1;
        //            break;
        //        default:
        //            return;
        //    }

        //    if (Plateau.CanMove(tempX, tempY))
        //    {
        //        this.X = tempX;
        //        this.Y = tempY;
        //    }
        //}

        //// Can be divided into two methods or implemented using strategy pattern(over-engineering)
        //private void Turn(char direction)
        //{
        //    // Turning left
        //    if (direction == 'l')
        //    {
        //        switch (Orientation)
        //        {
        //            case Direction.North:
        //                Orientation = Direction.West;
        //                return;
        //            case Direction.East:
        //                Orientation = Direction.North;
        //                return;
        //            case Direction.South:
        //                Orientation = Direction.East;
        //                return;
        //            case Direction.West:
        //                Orientation = Direction.South;
        //                return;
        //            default:
        //                return;
        //        }
        //    }
        //    // Turning right
        //    else if (direction == 'r')
        //    {
        //        switch (Orientation)
        //        {
        //            case Direction.North:
        //                Orientation = Direction.East;
        //                return;
        //            case Direction.East:
        //                Orientation = Direction.South;
        //                return;
        //            case Direction.South:
        //                Orientation = Direction.West;
        //                return;
        //            case Direction.West:
        //                Orientation = Direction.North;
        //                return;
        //            default:
        //                return;
        //        }
        //    }
        //}

    }
}
