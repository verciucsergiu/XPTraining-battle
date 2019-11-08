using System.Collections.Generic;
using System.Linq;
using CSharpFunctionalExtensions;

namespace Battle
{
    public sealed class Army
    {
        private readonly ICollection<Soldier> soldiers = new List<Soldier>();

        public Army(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public void EnrollSoldier(Soldier soldier)
        {
            soldiers.Add(soldier);
        }

        public Maybe<Soldier> GetFrontMan()
        {
            Maybe<Soldier> fightingSoldier = soldiers.FirstOrDefault();

            return fightingSoldier;
        }

        public void RemoveDeadSoldierIfNeeded(Soldier deadSoldier)
        {
            if (soldiers.Contains(deadSoldier))
            {
                soldiers.Remove(deadSoldier);
            }
        }
    }
}