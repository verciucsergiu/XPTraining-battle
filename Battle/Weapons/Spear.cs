using System.Collections.Generic;

namespace Battle.Weapons
{
    public class Spear : Weapon
    {
        public Spear() : base(2)
        {
        }

        public override IEnumerable<Weapon> SpecializedAgainst => new List<Weapon> { new Sword() };
    }
}
