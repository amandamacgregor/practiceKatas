using System;
using BowlingKata.Game;
using Shouldly;
using Xunit;

namespace BowlingKata.Tests
{
    public class BowlingGameShould
    {
        [Fact]
        public void TestSomething()
        {
            var game = new BowlingGame();
            game.ShouldNotBeNull();
        }
        [Fact]
        public void ShouldHaveScoreOfOne()
        {
            var game = new BowlingGame();
            game.Roll(1);
            game.Score().ShouldBe(1);
        }
        [Fact]
        public void ShouldHaveScoreOfThree()
        {
            var game = new BowlingGame();
            game.Roll(3);
            game.Score().ShouldBe(3);
        }
    }
}

// * roll(pins : int) is called each time the player rolls a ball.  The argument is the number of pins knocked down.