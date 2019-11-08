using CSharpFunctionalExtensions;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class WarTests
    {
        [Fact]
        public void Given_Fight_When_ArmiesAreProvided_Then_ArmyWithLastManStandingWins()
        {
            var attacker = ArmyFactory.Get();
            var soldier1 = Soldier.Create("AttackerSoldier").Value;
            attacker.EnrollSoldier(soldier1);
            var defender = ArmyFactory.Get();
            var soldier2 = Soldier.Create("DefenderSoldier").Value;
            defender.EnrollSoldier(soldier2);

            new War().WithAttacker(attacker).WithDefender(defender).Fight();
            
            attacker.GetFrontMan().Should().BeEquivalentTo(Maybe<Soldier>.From(soldier1));
            defender.GetFrontMan().Should().BeEquivalentTo(Maybe<Soldier>.None);
        }

        [Fact]
        public void Given_Fight_When_ArmyHasManySoldiers_Then_ArmyWithLastManStandingWins()
        {
            var lastSoldierStanding = Soldier.Create("marcel").Value;
            var attacker =
                ArmyFactory.WithSoldiers(lastSoldierStanding, Soldier.Create("petrica").Value, Soldier.Create("stefan").Value);
            var defender = ArmyFactory.WithSoldiers(Soldier.Create("marcel").Value, Soldier.Create("petrica").Value);
           
            new War().WithAttacker(attacker).WithDefender(defender).Fight();

            attacker.GetFrontMan().Should().BeEquivalentTo(Maybe<Soldier>.From(lastSoldierStanding));
            defender.GetFrontMan().Should().BeEquivalentTo(Maybe<Soldier>.None);
        }
    }
}