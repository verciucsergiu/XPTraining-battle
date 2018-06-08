using System;
using Battle.Weapons;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class SoldierTest
    {

        [Fact]
        public void Construction_ASoldierMustHaveAName()
        {
            var soldier = new Soldier("name");

            soldier.Name.Should().Be("name");
        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void Construction_ASoldierMustHaveAName_CannotBeBlank(string name)
        {
            Action act = () => new Soldier(name);
             
            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Construction_ANewSoldierAlwaysHasAweapon()
        {
            var soldier = new Soldier("Jeanne");

            soldier.Weapon.Should()
                .NotBeNull()
                .And
                .BeOfType<BareFist>();
        }

        [Fact]
        public void Construction_ASoldierCantNotHaveAWeapon()
        {
            var soldier = new Soldier("Jeanne");

            Action act = () => soldier.Weapon = null;

            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Construction_ASoldierCanFightASoldier()
        {
            var ryan = new Soldier("Private Ryan");
            var himmler = new Soldier("Himmler");

            ryan.Fight(himmler).Should().BeTrue();
        }

        [Fact]
        public void Construction_AxeWinsSword()
        {
            var ryan = new Soldier("Private Ryan")
            {
                Weapon = new Axe()
            };
            var himmler = new Soldier("Himmler")
            {
                Weapon = new Sword()
            };

            ryan.Fight(himmler).Should().BeTrue();
        }

        [Fact]
        public void Construction_SwordLoosesAxe()
        {
            var ryan = new Soldier("Private Ryan") {Weapon = new Axe()};
            var himmler = new Soldier("Himmler") {Weapon = new Sword()};

            himmler.Fight(ryan).Should().BeFalse();
        }
    }
}