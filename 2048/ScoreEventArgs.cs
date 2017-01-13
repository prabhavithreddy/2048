using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Factset
{
    public class ScoreEventArgs : EventArgs
    {
        public int Value;
        public string Direction;
        public ScoreEventArgs(int value, string movement)
        {
            this.Value = value;
            this.Direction = movement;
        }
    }
}
