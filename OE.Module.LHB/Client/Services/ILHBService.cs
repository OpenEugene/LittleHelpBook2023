using System.Collections.Generic;
using System.Threading.Tasks;
using OE.Module.LHB.Models;

namespace OE.Module.LHB.Services
{
    public interface ILHBService 
    {
        Task<List<Models.LHB>> GetLHBsAsync(int ModuleId);

        Task<Models.LHB> GetLHBAsync(int LHBId, int ModuleId);

        Task<Models.LHB> AddLHBAsync(Models.LHB LHB);

        Task<Models.LHB> UpdateLHBAsync(Models.LHB LHB);

        Task DeleteLHBAsync(int LHBId, int ModuleId);
    }
}
