using CSharpFunctionalExtensions;

namespace Battle.Weapons
{
    public class MagicPotion : SpecialWeapon
    {
        public MagicPotion() : base(0)
        {
        }

        public override WeaponInFight FightAgainst(Weapon weapon)
        {
            return Result.SuccessIf(weapon.BaseDamage % 2 == 0, new WeaponInFight(10), "Opponent damage is not even")
                .OnFailureCompensate(() => Result.Success(new WeaponInFight(0)))
                .Value;
        }
    }
}
