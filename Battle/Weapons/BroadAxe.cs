using System;
namespace Battle.Weapons
{
    public class BroadAxe : SpecialWeapon
    {
        public BroadAxe() : base(2 + new Axe().BaseDamage) { }
    }
}
