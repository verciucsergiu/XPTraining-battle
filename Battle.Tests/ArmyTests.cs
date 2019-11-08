using FluentAssertions;
using Moq;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTests
    {
        [Fact]
        public void Given_EnrollSoldier_When_SoldierIsProvided_Then_FrontManShouldBeThatSoldier()
        {
            var sut = ArmyFactory.Get();
            var soldier = Soldier.Create("Costel").Value;
            var secondSoldier = Soldier.Create("Marius").Value;
            sut.EnrollSoldier(soldier);
            sut.EnrollSoldier(secondSoldier);

            var frontMan = sut.GetFrontMan();

            frontMan.Should().Be(soldier);
        }

        [Fact]
        public void Given_CelebrateWin_WhenArmyWinsWithTwoRemainingSoldiers_Then_ShouldReportToHeadquarters()
        {
            var headquartersMock = new Mock<IHeadquarters>();
            var sut = new Army("test", headquartersMock.Object);
            sut.EnrollSoldier(SoldierFactory.Get());
            sut.EnrollSoldier(SoldierFactory.Get());

            sut.CelebrateWin();

            headquartersMock.Verify(x => x.ReportVictory(2));
        }

        [Fact]
        public void Given_FleeHome_Then_ShouldReportToHeadquarters()
        {
            var headquartersMock = new Mock<IHeadquarters>();
            var sut = new Army("test", headquartersMock.Object);
            var woundedSoldier = SoldierFactory.Get();
            sut.EnrollSoldier(woundedSoldier);
            sut.BuryFallenSoldier(woundedSoldier);
            var deadSoldier = SoldierFactory.Get();
            sut.EnrollSoldier(deadSoldier);
            sut.BuryFallenSoldier(deadSoldier);

            sut.FleeHome();

            headquartersMock.Verify(x => x.ReportCasualty(2));
        }

        [Fact]
        public void Given_BuryFallenSoldier_When_SoldierWasEnrolled_Then_ShouldBurySoldier()
        {
            var sut = ArmyFactory.Get();
            var soldier = SoldierFactory.Get();

            sut.BuryFallenSoldier(soldier);

            sut.GetFrontMan().HasNoValue.Should().BeTrue();
        }
    }
}