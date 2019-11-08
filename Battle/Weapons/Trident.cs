using System;
using System.Collections.Generic;
using System.Text;

namespace Battle.Weapons
{
    public class Trident : SpecialWeapon
    {
        public Trident() : base(3 * new Spear().BaseDamage) { }
    }
}
