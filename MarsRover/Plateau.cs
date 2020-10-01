using MarsRover.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Plateau : IPlateau
    {

        public int Width { get; set; }
        public int Height { get; set; }
        public List<Rover> Rovers { get; set; }

        public Plateau(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                // This shouldn't be hard codded message, should be custom Exception type
                throw new Exception("Width or height of the plateau must be greater than 0!");
            }
            Width = width;
            Height = height;
            Rovers = new List<Rover>();
        }

        public bool CanMove(int x, int y)
        {
            if (!((x >= 0) && (x <= Width) && (y >= 0) && (y <= Height)))
            {
                return false;
            }

            if (Rovers != null && Rovers.Count > 0)
            {
                foreach (var rover in Rovers)
                {
                    if (x == rover.X && y == rover.Y)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


    }
}
