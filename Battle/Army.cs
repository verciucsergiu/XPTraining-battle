using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle
{
    public class Army
    {
        private readonly List<Soldier> _soldiers;

        public IHeadquarters Headquarters { get; set; }

        public IReadOnlyCollection<Soldier> Soldiers => _soldiers;
        public Soldier FrontMan => _soldiers.FirstOrDefault();

        public Army(IHeadquarters headquarters)
        {
            Headquarters = headquarters;
            _soldiers = new List<Soldier>();
        }

        public void EnlistSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
            soldier.Id = Headquarters.ReportEnlistment(soldier.Name);
        }

        public bool Engage(Army defenders)
        {
            if (this == defenders)
                throw new ArgumentException("argument cant fight itself, you stupid");

            var hasWon = false;

            while (_soldiers.Any())
            {
                var attacker = FrontMan;
                var defender = defenders.FrontMan;

                if (defender == null)
                {
                    hasWon = true;
                    break;
                }

                if (attacker.Fight(defender))
                {
                    defenders.Headquarters.ReportCasualty(defender.Id);
                    defenders._soldiers.Remove(defender);
                }
                else
                {
                    Headquarters.ReportCasualty(attacker.Id);
                    _soldiers.Remove(attacker);
                }
            }

            var winner = hasWon ? this : defenders;
            winner.Headquarters.ReportVictory(winner.Soldiers.Count);

            return hasWon;
        }
    }
}