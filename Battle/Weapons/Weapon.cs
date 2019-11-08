using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace Battle.Weapons
{
    public abstract class Weapon : ValueObject
    {
        protected Weapon(int damage)
        {
            Name = this.GetType().Name;
            BaseDamage = damage;
        }

        public string Name { get; }

        public int BaseDamage { get; }

        public virtual WeaponInFight FightAgainst(Weapon weapon)
        {
            return Result.SuccessIf(this.SpecializedAgainst.Contains(weapon), new WeaponInFight(BaseDamage + 3), "Not fighting against specialized weapon")
                .OnFailureCompensate(() => Result.Success(new WeaponInFight(BaseDamage)))
                .Value;
        }

        public virtual bool CanBeWieldedBy(Soldier soldier)
        {
            return true;
        }

        public virtual IEnumerable<Weapon> SpecializedAgainst => new List<Weapon>();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Name;
        }
    }
}
