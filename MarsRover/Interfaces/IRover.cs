using MarsRover.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface IRover
    {
        void Execute(IList<Command> commands);
    }
}
