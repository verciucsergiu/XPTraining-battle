using System;
using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace Battle
{
    public sealed class Army
    {
        private readonly IHeadquarters headquarters;
        private readonly ICollection<Soldier> soldiers = new List<Soldier>();
        private int casualties = 0;

        public Army(string name, IHeadquarters headquarters)
        {
            this.headquarters = headquarters;
            Name = name;
        }

        public string Name { get; private set; }

        public void EnrollSoldier(Soldier soldier)
        {
            soldiers.Add(soldier);
            var enlistmentId = headquarters.ReportEnlistment(soldier.Name);
            soldier.SetId(enlistmentId);
        }

        public Maybe<Soldier> GetFrontMan()
        {
            Maybe<Soldier> fightingSoldier = soldiers.FirstOrDefault();

            return fightingSoldier;
        }

        public void BuryFallenSoldier(Soldier deadSoldier)
        {
            if (soldiers.Contains(deadSoldier))
            {
                soldiers.Remove(deadSoldier);
                casualties++;
                headquarters.ReportCasualty(deadSoldier.Id);
            }
        }

        public void CelebrateWin()
        {
            headquarters.ReportVictory(soldiers.Count);
        }

        public void FleeHome()
        {
            headquarters.ReportCasualty(casualties);
        }
    }
}