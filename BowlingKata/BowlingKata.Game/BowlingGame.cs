using System;

namespace BowlingKata.Game
{
    public class BowlingGame
    {
        private int _score;
        public void Roll(int pins) 
        {
            _score = pins;
        }

        public int Score() 
        {
            return _score;
        }
    }
}

