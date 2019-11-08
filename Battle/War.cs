namespace Battle
{
    public sealed class War
    {
        private Army attacker;
        private Army defender;

        public War WithAttacker(Army attackerArmy)
        {
            this.attacker = attackerArmy;
            return this;
        }
        
        public War WithDefender(Army defender)
        {
            this.defender = defender;
            return this;
        }

        public void Fight()
        {
            while (attacker.GetFrontMan() != null || defender.GetFrontMan() != null)
            {
                var attackerFrontMan = attacker.GetFrontMan();
                var defenderFrontMan = defender.GetFrontMan();

                var attackResult =  attackerFrontMan.Attack(defenderFrontMan);
                attacker.HandleFightResult(attackResult);
                defender.HandleFightResult(attackResult);
            }
        }
    }
}