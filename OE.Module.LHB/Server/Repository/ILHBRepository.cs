using System.Collections.Generic;
using OE.Module.LHB.Models;

namespace OE.Module.LHB.Repository
{
    public interface ILHBRepository
    {
        IEnumerable<Models.LHB> GetLHBs(int ModuleId);
        Models.LHB GetLHB(int LHBId);
        Models.LHB GetLHB(int LHBId, bool tracking);
        Models.LHB AddLHB(Models.LHB LHB);
        Models.LHB UpdateLHB(Models.LHB LHB);
        void DeleteLHB(int LHBId);
    }
}
