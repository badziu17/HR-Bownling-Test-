using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Game
    {
        List<Roll> _rolls;
        public Game()
        {
            _rolls = new List<Roll>();
        }

        public void Roll(int pins)
        {
            _rolls.Add(new Roll()
            {
                KnockedPinsCount = pins
            });
        }

        //public int TotalScores()
        //{
        //    int result = 0;

        //    for (int i = 0; i < _rolls.Count; i++)
        //    {
        //        //_rolls[i].KnockedPinsCount;
        //        if (i + 1 < _rolls.Count && IsSpare(i))
        //        {
        //            result += 10 + _rolls[i + 2].KnockedPinsCount;
        //            i++;
        //        }
        //        else
        //        {
        //            result += _rolls[i].KnockedPinsCount;
        //        }
        //    }

        //    return result;
        //}

        public int TotalScores()
        {
            int result = 0;
            int rollIndicator = 0;
            int frameIndicator = 0; 

            while (frameIndicator < 10)
            {
                if (IsStrike(rollIndicator))
                {
                    result += 10 + _rolls[rollIndicator + 1].KnockedPinsCount + _rolls[rollIndicator + 2].KnockedPinsCount;
                    rollIndicator += 1;
                }
                else if (IsSpare(rollIndicator))
                {
                    result += 10 + _rolls[rollIndicator + 2].KnockedPinsCount;
                    rollIndicator += 2;
                }
                else
                {
                    result += _rolls[rollIndicator].KnockedPinsCount + _rolls[rollIndicator + 1].KnockedPinsCount;
                    rollIndicator += 2;
                }
                frameIndicator++;
            }

            return result;
        }

        private bool IsStrike(int rollIndicator)
        {
            return _rolls[rollIndicator].KnockedPinsCount == 10;
        }

        private bool IsSpare(int i)
        {
            return _rolls[i].KnockedPinsCount + _rolls[i + 1].KnockedPinsCount == 10;
        }
    }
}
