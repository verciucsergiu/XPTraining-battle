using System.Linq;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class WarTests
    {
        [Fact]
        public void Given_Fight_When_ArmiesAreProvided_Then_ArmyWithLastManStandingWins()
        {
            var attacker = new Army("OasteaLuiStefan");
            var soldier1 = Soldier.Create("AttackerSoldier").Value;
            attacker.EnrollSoldier(soldier1);
            var defender = new Army("OasteaLuiSuleiman");
            var soldier2 = Soldier.Create("DefenderSoldier").Value;
            defender.EnrollSoldier(soldier2);

            new War().WithAttacker(attacker).WithDefender(defender).Fight();

            attacker.GetFrontMan().Should().NotBeNull();
            defender.GetFrontMan().Should().BeNull();
        }

        [Fact]
        public void Given_Fight_When_ArmyHasManySoldiers_Then_ArmyWithLastManStandingWins()
        {
            var attacker =
                ArmyFactory.WithSoldiers(Soldier.Create("marcel").Value, Soldier.Create("petrica").Value, Soldier.Create("stefan").Value);
            var defender = ArmyFactory.WithSoldiers(Soldier.Create("marcel").Value, Soldier.Create("petrica").Value);
           
            new War().WithAttacker(attacker).WithDefender(defender).Fight();

            attacker.GetFrontMan().Should().NotBeNull();
            defender.GetFrontMan().Should().BeNull();
        }
    }

    public static class ArmyFactory
    {
        public static Army WithSoldiers(params Soldier[] soldiers)
        {
            var army = new Army("test");
            soldiers.ToList().ForEach(x => army.EnrollSoldier(x));
            return army;
        }
    }
}