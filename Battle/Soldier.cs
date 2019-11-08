using Battle.Weapons;
using CSharpFunctionalExtensions;
namespace Battle
{
    public class Soldier
    {
        private Soldier(string name)
        {
            Name = name;
        }

        public static Result<Soldier> Create(string name)
        {
            return Result.SuccessIf(!string.IsNullOrEmpty(name?.Trim()), "Name cannot be blank!")
                .Map(() => new Soldier(name));
        }

        public int Id { get; private set; }

        public string Name { get; }

        public bool IsHighlyTrained { get; private set; }

        public Weapon Weapon { get; private set; } = new BareFist();

        public Soldier Train()
        {
            this.IsHighlyTrained = true;
            return this;
        }

        public void SetId(int id)
        {
            Id = id;
        }

        public Soldier WithWeapon(Weapon weapon)
        {
            this.Weapon = weapon;
            return this;
        }

        public FightResult Attack(Soldier other)
        {
            var attackerDamage = this.Weapon.FightAgainst(other.Weapon).FightingDamage;
            var defenderDamage = other.Weapon.FightAgainst(this.Weapon).FightingDamage;

            if (attackerDamage >= defenderDamage)
            {
                return new FightResult(this, other);
            }

            return new FightResult(other, this);
        }

    }
}