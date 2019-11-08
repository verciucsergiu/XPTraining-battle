using System.Linq;

namespace Battle.Tests
{
    public class ArmyFactory
    {
        public static Army Get() => new Army("test", new HeadquartersStub());

        public static Army WithSoldiers(params Soldier[] soldiers)
        {
            var army = Get();
            soldiers.ToList().ForEach(x => army.EnrollSoldier(x));
            return army;
        }
    }
}