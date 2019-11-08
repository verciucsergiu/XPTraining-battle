using System;
using Battle.Weapons;
using FluentAssertions;
using Xunit;

namespace Battle.Tests
{
    public class SoldierTest
    {

        [Fact]
        public void Given_Create_When_NameIsValid_Then_ShouldSucceed()
        {
            var result = Soldier.Create("name");

            result.IsSuccess.Should().BeTrue();
            result.Value.Name.Should().Be("name");
        }

        [Theory]
        [InlineData("")]
        [InlineData("        ")]
        [InlineData(null)]
        public void Given_Create_When_NameIsBlank_Then_ShouldFail(string name)
        {
            var result = Soldier.Create(name);

            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Name cannot be blank!");
        }

        [Fact]
        public void Construction_ASoldierMustHaveAsWeaponBareFist()
        {
            var result = Soldier.Create("name");

            result.Value.Weapon.Name.Should().Be("BareFist");
        }

        [Fact]
        public void Given_Attack_When_BothHaveSameWeapon_Then_AttackerShouldWin()
        {
            var attacker = SoldierFactory.Get();
            var defender = SoldierFactory.Get();

            var result = attacker.Attack(defender);

            result.Winner.Should().Be(attacker);
            result.Loser.Should().Be(defender);
        }

        [Fact]
        public void Given_Attack_When_AttackerHasBetterWeapon_Then_ShouldWin()
        {
            var attacker = SoldierFactory.WithWeapon(new Axe());
            var defender = SoldierFactory.Get();

            var result = attacker.Attack(defender);

            result.Winner.Should().Be(attacker);
            result.Loser.Should().Be(defender);
        }

        [Fact]
        public void Given_Attack_When_AttackerHasWorseWeapon_Then_ShouldLose()
        {
            var attacker = SoldierFactory.WithWeapon(new Sword());
            var defender = SoldierFactory.WithWeapon(new Axe());

            var result = attacker.Attack(defender);

            result.Winner.Should().Be(defender);
            result.Loser.Should().Be(attacker);
        }
    }
}