using Battle.Weapons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battle.Tests
{
    public class SoldierFactory
    {
        public static Soldier Get() => Soldier.Create("name").Value;

        public static Soldier WithWeapon(Weapon weapon) => Get().WithWeapon(weapon);
    }
}
