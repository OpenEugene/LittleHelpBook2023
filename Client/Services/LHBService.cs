using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using OE.LHB.Models;

namespace OE.LHB.Services
{
    public class LHBService : ServiceBase, ILHBService, IService
    {
        public LHBService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("LHB");

        public async Task<List<Models.LHB>> GetLHBsAsync(int ModuleId)
        {
            List<Models.LHB> LHBs = await GetJsonAsync<List<Models.LHB>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return LHBs.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.LHB> GetLHBAsync(int LHBId, int ModuleId)
        {
            return await GetJsonAsync<Models.LHB>(CreateAuthorizationPolicyUrl($"{Apiurl}/{LHBId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.LHB> AddLHBAsync(Models.LHB LHB)
        {
            return await PostJsonAsync<Models.LHB>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, LHB.ModuleId), LHB);
        }

        public async Task<Models.LHB> UpdateLHBAsync(Models.LHB LHB)
        {
            return await PutJsonAsync<Models.LHB>(CreateAuthorizationPolicyUrl($"{Apiurl}/{LHB.LHBId}", EntityNames.Module, LHB.ModuleId), LHB);
        }

        public async Task DeleteLHBAsync(int LHBId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{LHBId}", EntityNames.Module, ModuleId));
        }
    }
}
