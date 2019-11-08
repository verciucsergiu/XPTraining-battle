namespace Battle
{
    public sealed class FightResult
    {
        public FightResult(Soldier winner, Soldier loser)
        {
            Winner = winner;
            Loser = loser;
        }

        public Soldier Winner { get; private set; }

        public Soldier Loser { get; private set; }
    }
}