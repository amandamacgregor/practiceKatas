using Xunit;
using Shouldly;
using ZombieKata.Game;
using static ZombieKata.Tests.SurvivorFactory;

namespace ZombieKata.Tests
{
    public class SurvivorShould
    {
        private Survivor _survivor;

        [Fact]
        public void BeWoundedWhenHarmed()
        {
            _survivor = CreateHealthyPhillip();

            _survivor.Harm();
            
            _survivor.Wounds.ShouldBe(1);
        }

        [Fact]
        public void DieWithTwoWounds()
        {
            _survivor = CreateHealthyPhillip();
            var lethalAmountOfWounds = 2;

            for (var i = 0; i < lethalAmountOfWounds; i++)
            {
                _survivor.Harm();
            }
            
            _survivor.IsDead.ShouldBeTrue();
        }

        [Fact]
        public void NotBeWoundedAfterDeath()
        {
            _survivor = CreateHealthyPhillip();
            var lethalAmountOfWounds = 2;

            for (var i = 0; i < lethalAmountOfWounds + 1; i++)
            {
                _survivor.Harm();
            }
            
            _survivor.Wounds.ShouldBe(2);
        }
    }
}