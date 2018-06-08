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

        private void ReportCasualty(Soldier soldier)
        {
            _soldiers.Remove(soldier);
            Headquarters.ReportCasualty(soldier.Id);
        }

        public void EnlistSoldier(Soldier soldier)
        {
            _soldiers.Add(soldier);
            soldier.Id = Headquarters.ReportEnlistment(soldier.Name);
        }

        public bool Engage(Army defenders)
        {
            if (this == defenders)
                throw new ArgumentException("army cant fight itself, you stupid");

            if (defenders.FrontMan == null)
            {
                this.Headquarters.ReportVictory(_soldiers.Count);
                return true;
            }

            if (this.FrontMan.Fight(defenders.FrontMan))
            {   
                defenders.ReportCasualty(defenders.FrontMan);
                return this.Engage(defenders);
            }

            return !defenders.Engage(this);
        }
    }
}