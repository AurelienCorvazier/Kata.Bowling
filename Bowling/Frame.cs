using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Frame
    {
        public int Score { get; private set; } = 0;
        public bool IsSpare { get; private set; }
        public bool IsStrike { get; private set; }

        public Frame(int pins, bool isSpare, bool isStrike)
        {
            Score = pins; 
            IsSpare = isSpare;
            IsStrike = isStrike;
        }

        public void AddScore(int score)
        {
            Score += score;
        }
    }
}
