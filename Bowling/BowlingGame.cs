using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling
{ 
    public class BowlingGame
    {
        public List<Frame> Frames { get;  } = new List<Frame>();

        public void Roll(int pins)
        {
            if (!(0 <= pins && pins <= 9))
                throw new Exception("0 <= pins <= 9");

            Update_Score_Previous_Frame(pins);
            Frames.Add(new Frame(pins, false, false));
        }

        private void Update_Score_Previous_Frame(int pins)
        {
            PreviousFrame(pins);
            PreviousPreviousFrame(pins);
        }

        private void PreviousFrame(int pins)
        {
            if (!Frames.Any())
                return;

            var previous = Frames.Last();
            if (previous.IsSpare || previous.IsStrike)
                previous.AddScore(pins);
        }

        private void PreviousPreviousFrame(int pins)
        {
            if (Frames.Count() < 2)
                return;

            var previousPrevious = Frames.ElementAt(Frames.Count() - 2);
            if (previousPrevious.IsStrike)
                previousPrevious.AddScore(pins);

        }
        public int Score() => Frames.Sum(e => e.Score);

        public void Spare()
        {
            Update_Score_Previous_Frame(10);
            Frames.Add(new Frame(10, true, false));
        }

        public void Strike()
        {
            Update_Score_Previous_Frame(10);
            Frames.Add(new Frame(10, false, true));
        }
    }
}
