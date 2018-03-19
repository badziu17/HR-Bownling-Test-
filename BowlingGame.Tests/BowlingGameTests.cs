using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class BowlingGameTests
    {
        private Game _game;
        [SetUp]
        public void Init()
        {
            _game = new Game();
        }
        [Test]
        public void Should_GutterGame_ScoresZero()
        {
            for (int i = 0; i < 20; i++)
            {
                _game.Roll(0);
            }

            Assert.That(_game.TotalScores(), Is.EqualTo(0));

        }
        [Test]
        public void Should_AllOnes_ScoreTwenty()
        {
            for (int i = 0; i < 20; i++)
            {
                _game.Roll(1);
            }
            Assert.That(_game.TotalScores(), Is.EqualTo(20));
        }

        [Test]
        public void Should_SpareThan3ThenAllMisses_Scores16()
        {
            //spare in the first time

            _game.Roll(6);
            _game.Roll(4);
            // that 3 pins
            _game.Roll(3);
            
            //then all gutters missed 
            for (int i = 0; i < 17; i++)
            {
                _game.Roll(0);
            }
            Assert.That(_game.TotalScores(), Is.EqualTo(16));
        }

        [Test]
        public void Should_StrikeThen3pinsThen4pinsThenAllMisses_Scores24()
        {
            _game.Roll(10);
            _game.Roll(3);
            // that 3 pins
            _game.Roll(4);

            //then all gutters missed 
            for (int i = 0; i < 16; i++)
            {
                _game.Roll(0);
            }
            Assert.That(_game.TotalScores(), Is.EqualTo(24));
        }
        [Test]
        public void Should_PerfectGame_Scores300()
        {
            for (int i = 0; i < 12; i++)
            {
                _game.Roll(10);
            }
            Assert.That(_game.TotalScores(), Is.EqualTo(300));
        }
    }
}

