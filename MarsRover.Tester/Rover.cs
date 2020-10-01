using MarsRover.Enums;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Tester
{
    class Rover
    {
        private MarsRover.Plateau plateau;
        private int width;
        private int height;

        private MarsRover.Rover rover;
        private int x;
        private int y;
        private MarsRover.Enums.Direction orientation;


        [SetUp]
        public void Setup()
        {
            // Basic Plateau and Rover initialization
            width = 5;
            height = 5;
            plateau = new MarsRover.Plateau(width, height);

            x = 1;
            y = 2;
            orientation = MarsRover.Enums.Direction.South;
            rover = new MarsRover.Rover(x, y, orientation, plateau);
        }

        [Test]
        public void RunRoverRunCase1()
        {
            string[] location = { "1", "2", "N" };
            List<Command> commantsList = new List<Enums.Command>
            {
                Command.TurnLeft,
                Command.GoForward,
                Command.TurnLeft,
                Command.GoForward,
                Command.TurnLeft,
                Command.GoForward,
                Command.TurnLeft,
                Command.GoForward,
                Command.GoForward,
            };

            x = location[0].ToInt();
            y = location[1].ToInt();
            orientation = Utils.Enumeration.GetValueFromShortName<Direction>(location[2]);
            rover = new MarsRover.Rover(x, y, orientation, plateau);

            rover.Execute(commantsList);

            Assert.AreEqual(rover.X, 1);
            Assert.AreEqual(rover.Y, 3);
            Assert.AreEqual(rover.Orientation, MarsRover.Enums.Direction.North);
        }

        [Test]
        public void RunRoverRunCase2()
        {
            string[] location = { "3", "3", "E" };
            List<Command> commantsList = new List<Enums.Command>
            {
                Command.GoForward,
                Command.GoForward,
                Command.TurnRight,
                Command.GoForward,
                Command.GoForward,
                Command.TurnRight,
                Command.GoForward,
                Command.TurnRight,
                Command.TurnRight,
                Command.GoForward,
            };

            x = location[0].ToInt();
            y = location[1].ToInt();
            orientation = Utils.Enumeration.GetValueFromShortName<Direction>(location[2]);
            rover = new MarsRover.Rover(x, y, orientation, plateau);

            rover.Execute(commantsList);

            Assert.AreEqual(rover.X, 5);
            Assert.AreEqual(rover.Y, 1);
            Assert.AreEqual(rover.Orientation, MarsRover.Enums.Direction.East);
        }
    }
}
