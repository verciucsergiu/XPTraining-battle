namespace Battle.Weapons
{
    public class WeaponInFight
    {
        public WeaponInFight(int damage)
        {
            FightingDamage = damage;
        }

        public int FightingDamage { get; private set; }
    }
}
