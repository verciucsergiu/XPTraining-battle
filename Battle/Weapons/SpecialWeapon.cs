namespace Battle.Weapons
{
    public abstract class SpecialWeapon : Weapon
    {
        protected SpecialWeapon(int damage) : base(damage)
        {
        }

        public override bool CanBeWieldedBy(Soldier soldier)
        {
            return soldier.IsHighlyTrained;
        }
    }
}
