using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Enums
{
    public enum Direction
    {
        [ShortName("N")]
        North = 0,
        [ShortName("E")]
        East = 1,
        [ShortName("S")]
        South = 2,
        [ShortName("W")]
        West = 3
    }

    public class ShortNameAttribute : System.Attribute
    {
        private string _value;

        public ShortNameAttribute(string value = "")
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }
}
