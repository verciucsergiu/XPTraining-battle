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

        public string Name { get; }

        public Weapon Weapon { get; private set; } = new BareFist();

        public Soldier WithWeapon(Weapon weapon)
        {
            this.Weapon = weapon;
            return this;
        }

        public FightResult Attack(Soldier other)
        {
            if(this.Weapon.Damage >= other.Weapon.Damage)
            {
                return new FightResult(this, other);
            }

            return new FightResult(other, this);
        }

    }
}