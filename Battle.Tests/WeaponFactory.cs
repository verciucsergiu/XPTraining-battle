using Battle.Weapons;
namespace Battle.Tests
{
    public static class WeaponFactory
    {
        public static SpecialWeapon GetSpecialWeapon() => new TwoHandedSword();
    }
}
