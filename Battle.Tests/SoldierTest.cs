using System;
using System.Collections;
using System.Collections.Generic;
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
        public void Given_Create_Soldier_Should_NotBeTrained()
        {
            var result = Soldier.Create("name");

            result.IsSuccess.Should().BeTrue();
            result.Value.IsHighlyTrained.Should().BeFalse();
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
            var defender = SoldierFactory.WithWeapon(new Sword());
            var attacker = SoldierFactory.WithWeapon(new Axe());

            var result = attacker.Attack(defender);

            result.Winner.Should().Be(defender);
            result.Loser.Should().Be(attacker);
        }

        [Fact]
        public void Given_Train_Should_MakeSoldierTrained()
        {
            var soldier = SoldierFactory.Get();

            soldier.Train();

            soldier.IsHighlyTrained.Should().BeTrue();
        }

        [Fact]
        public void Given_Weapon_Should_BeWieldableByAnySoldier()
        {
            var soldier = SoldierFactory.Get();
            var weapon = new Axe();

            var result = weapon.CanBeWieldedBy(soldier);

            result.Should().BeTrue();
        }

        [Fact]
        public void Given_SpecialWeapon_ShouldNotBeWieldableBySimpleSoldier()
        {
            var soldier = SoldierFactory.Get();
            var sut = WeaponFactory.GetSpecialWeapon();

            var result = sut.CanBeWieldedBy(soldier);

            result.Should().BeFalse();
        }

        [Fact]
        public void Given_SpecialWeapon_ShouldBeWieldableByHighlyTrainedSoldier()
        {
            var soldier = SoldierFactory.HighlyTrained();
            var sut = WeaponFactory.GetSpecialWeapon();

            var result = sut.CanBeWieldedBy(soldier);

            result.Should().BeTrue();
        }

        [Fact]
        public void Given_MagicPotion_When_FightingAgainstOddDamage_Then_ShouldHave0Damage()
        {
            var sut = new MagicPotion();

            var damage = sut.FightAgainst(new TwoHandedSword()).FightingDamage;

            damage.Should().Be(0);
        }

        [Fact]
        public void Given_MagicPotion_When_FightingAgainstEvenDamage_Then_ShouldHave10Damage()
        {
            var sut = new MagicPotion();

            var damage = sut.FightAgainst(new Sword()).FightingDamage;

            damage.Should().Be(10);
        }

        [Fact]
        public void Given_BroadAxe_Should_HavePlus2OverAxeDamage()
        {
            var axe = new Axe();
            var broadAxe = new BroadAxe();

            broadAxe.BaseDamage.Should().Be(2 + axe.BaseDamage);
        }

        [Fact]
        public void Given_Trident_Should_Have3TimesOverSpear()
        {
            var spear = new Spear();
            var trident = new Trident();

            trident.BaseDamage.Should().Be(3 * spear.BaseDamage);
        }

        [ClassData(typeof(SpecializedWeaponsData))]
        [Theory]
        public void Given_SpecializedWeapon_When_FightingAgainstSpecification_Should_HaveFightingDamageIncreasedBy3(Weapon specializedWeapon, Weapon weakAgainstSpecialized)
        {
            var specializedFightingDamage = specializedWeapon.FightAgainst(weakAgainstSpecialized).FightingDamage;

            specializedFightingDamage.Should().Be(specializedWeapon.BaseDamage + 3);
        }

        public class SpecializedWeaponsData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new Axe(), new Spear() };
                yield return new object[] { new Spear(), new Sword() };
                yield return new object[] { new Sword(), new Axe() };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
    }
}