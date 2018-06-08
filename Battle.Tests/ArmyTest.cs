using System;
using System.Collections.Generic;
using System.Text;
using Battle.Weapons;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Battle.Tests
{
    public class ArmyTest
    {
        private readonly IHeadquarters _hqMock = Substitute.For<IHeadquarters>();

        [Fact]
        public void Army_CanEnlistSoldiers()
        {
            var army = new Army(_hqMock);
            var soldier = new Soldier("Private Ryan");
            army.EnlistSoldier(soldier);
            army.Soldiers.Should().Contain(soldier);
        }

        [Fact]
        public void Army_HasFrontMan()
        {
            var army = new Army(_hqMock);
            var soldier = new Soldier("Private Ryan");
            army.EnlistSoldier(soldier);
            army.EnlistSoldier(new Soldier("Himmler"));
            army.FrontMan.Should().Be(soldier);
        }

        [Fact]
        public void Army_CanFightOtherArmyAndWin()
        {
            var axe = new Axe();
            var ryan = new Soldier("Private Ryan");
            var eisenhower = new Soldier("eisenhower")
            {
                Weapon = axe
            };
            var alliance = new Army(_hqMock);
            alliance.EnlistSoldier(ryan);
            alliance.EnlistSoldier(eisenhower);

            var sword = new Sword();
            var himmler = new Soldier("himmler")
            {
                Weapon = sword
            };
            var germans = new Army(_hqMock);
            germans.EnlistSoldier(himmler);

            alliance.Engage(germans).Should().BeTrue();
            alliance.Soldiers.Should().OnlyContain(s => s == eisenhower);
        }

        [Fact]
        public void Army_CanFightOtherArmyAndLose()
        {
            var axe = new Axe();
            var ryan = new Soldier("Private Ryan");
            var eisenhower = new Soldier("eisenhower")
            {
                Weapon = axe
            };
            var alliance = new Army(_hqMock);
            alliance.EnlistSoldier(ryan);
            alliance.EnlistSoldier(eisenhower);

            var sword = new Sword();
            var himmler = new Soldier("himmler")
            {
                Weapon = sword
            };
            var germans = new Army(_hqMock);
            germans.EnlistSoldier(himmler);

            germans.Engage(alliance).Should().BeFalse();
            alliance.Soldiers.Should().OnlyContain(s => s == eisenhower);
        }

        [Fact]
        public void Army_CantFightItself()
        {
            var army = new Army(_hqMock);

            Action act = () => army.Engage(army);

            act.Should().Throw<ArgumentException>();
        }
    }
}
