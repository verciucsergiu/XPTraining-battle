using System.Collections.Generic;
using System.Linq;

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

        public Soldier GetFrontMan()
        {
            var fightingSoldier = soldiers.FirstOrDefault();

            return fightingSoldier;
        }

        public void HandleFightResult(FightResult fightResult)
        {
            if (soldiers.Contains(fightResult.Loser))
            {
                soldiers.Remove(fightResult.Loser);
            }
        }
    }
}