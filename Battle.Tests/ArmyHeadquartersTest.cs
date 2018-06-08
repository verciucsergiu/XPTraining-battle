using System;
using NSubstitute;
using Xunit;

namespace Battle.Tests
{
    public class ArmyHeadquartersTest
    {
        [Fact]
        public void Army_ReportsNewSoldier()
        {
            var hqMock = Substitute.For<IHeadquarters>();
            hqMock.ReportEnlistment(Arg.Any<string>()).Returns(Guid.NewGuid());

            var army = new Army(hqMock);
            army.EnlistSoldier(new Soldier("Private Ryan"));

            hqMock.Received().ReportEnlistment(Arg.Any<string>());
        }

        [Fact]
        public void Army_CasualtyGetsReportedToHq()
        {
            var hqMock = Substitute.For<IHeadquarters>();

            var soldierId = Guid.NewGuid();
            hqMock.ReportEnlistment(Arg.Any<string>()).Returns(soldierId);

            var winners = new Army(hqMock);
            winners.EnlistSoldier(new Soldier("Private Ryan"));

            var losers = new Army(hqMock);
            losers.EnlistSoldier(new Soldier("Himmler"));

            winners.Engage(losers);

            hqMock.Received().ReportCasualty(soldierId);
        }

        [Fact]
        public void Army_WarWonGetsReportedToHq()
        {
            var winnerHqMock = Substitute.For<IHeadquarters>();
            winnerHqMock.ReportEnlistment(Arg.Any<string>()).Returns(Guid.NewGuid());

            var loserHqMock = Substitute.For<IHeadquarters>();
            loserHqMock.ReportEnlistment(Arg.Any<string>()).Returns(Guid.NewGuid());

            var winners = new Army(winnerHqMock);
            winners.EnlistSoldier(new Soldier("Private Ryan"));

            var losers = new Army(loserHqMock);
            losers.EnlistSoldier(new Soldier("Himmler"));

            winners.Engage(losers);

            winnerHqMock.Received().ReportVictory(1);
            loserHqMock.DidNotReceive().ReportVictory(Arg.Any<int>());
        }
    }
}
