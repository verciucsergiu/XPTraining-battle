namespace Battle.Tests
{
    public class HeadquartersStub : IHeadquarters
    {
        public int ReportEnlistment(string soldierName)
        {
            return 1;
        }

        public void ReportCasualty(int soldierId)
        {
        }

        public void ReportVictory(int remainingNumberOfSoldiers)
        {
        }
    }
}