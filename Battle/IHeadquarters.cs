using System;

namespace Battle
{
    public interface IHeadquarters
    {
        Guid ReportEnlistment(string soldierName);

        void ReportCasualty(Guid soldierId);

        void ReportVictory(int remainingNumberOfSoldiers);
    }

}
