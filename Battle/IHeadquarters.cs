namespace Battle
{
    public interface IHeadquarters
    {
        int ReportEnlistment(string soldierName);
        
        void ReportCasualty(int soldierId);

        void ReportVictory(int remainingNumberOfSoldiers);
    }
}