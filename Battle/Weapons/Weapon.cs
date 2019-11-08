using System;
using System.Collections.Generic;
using System.Text;

namespace Battle.Weapons
{
    public abstract class Weapon
    {
        protected Weapon(int damage)
        {
            Name = this.GetType().Name;
            Damage = damage;
        }

        public string Name { get; }

        public int Damage { get; }
    }
}
