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
            FightUntilLastManStanding();

            CleanBattlefield();
        }

        private void FightUntilLastManStanding()
        {
            while (attacker.GetFrontMan().HasValue && defender.GetFrontMan().HasValue)
            {
                var attackerFrontMan = attacker.GetFrontMan().Value;
                var defenderFrontMan = defender.GetFrontMan().Value;

                var attackResult = attackerFrontMan.Attack(defenderFrontMan);
                attacker.BuryFallenSoldier(attackResult.Loser);
                defender.BuryFallenSoldier(attackResult.Loser);
            }
        }

        private void CleanBattlefield()
        {
            var didAttackerWin = attacker.GetFrontMan().HasValue;

            if (didAttackerWin)
            {
                attacker.CelebrateWin();
                defender.FleeHome();
            }

            defender.CelebrateWin();
            attacker.FleeHome();
        }
    }
}