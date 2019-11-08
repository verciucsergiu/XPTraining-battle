using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTests
    {
        [Fact]
        public void Given_EnrollSoldier_When_SoldierIsProvided_Then_FrontManShouldBeThatSoldier()
        {
            var sut = new Army("Oastea cea mare");
            var soldier = Soldier.Create("Costel").Value;
            var secondSoldier = Soldier.Create("Marius").Value;
            sut.EnrollSoldier(soldier);
            sut.EnrollSoldier(secondSoldier);

            var frontMan = sut.GetFrontMan();

            frontMan.Should().Be(soldier);
        }
    }
}