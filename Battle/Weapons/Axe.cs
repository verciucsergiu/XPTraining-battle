using System.Collections.Generic;
namespace Battle.Weapons
{
    public class Axe : Weapon
    {
        public Axe() : base(3)
        {
        }

        public override IEnumerable<Weapon> SpecializedAgainst => new List<Weapon> { new Spear() };
    }
}
