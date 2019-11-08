using System.Collections.Generic;

namespace Battle.Weapons
{
    public class Sword : Weapon
    {
        public Sword() : base(2)
        {
        }

        public override IEnumerable<Weapon> SpecializedAgainst => new List<Weapon> { new Axe() };
    }
}
