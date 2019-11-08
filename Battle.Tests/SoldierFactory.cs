using Battle.Weapons;

namespace Battle.Tests
{
    public class SoldierFactory
    {
        public static Soldier Get() => Soldier.Create("name").Value;

        public static Soldier WithWeapon(Weapon weapon) => Get().WithWeapon(weapon);

        public static Soldier HighlyTrained() => Get().Train();
    }
}
