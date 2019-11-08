namespace Battle
{
    public sealed class FightResult
    {
        public Soldier Winner { get; private set; }

        public Soldier Loser { get; private set; }
    }
}