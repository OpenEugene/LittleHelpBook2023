using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace OE.LHB.Services
{
    public class ProviderService : ServiceBase, IService
    {
        public ProviderService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Provider");
        
        public async Task<List<Models.Provider>> GetProvidersAsync()
        {
            List<Models.Provider> LHBs = await GetJsonAsync<List<Models.Provider>>($"{Apiurl}");
            return LHBs.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.Provider> GetProviderAsync(int id)
        {
            return await GetJsonAsync<Models.Provider>($"{Apiurl}/{id}");
        }

        public async Task<Models.Provider> AddProviderAsync(Models.Provider provider)
        {
            return await PostJsonAsync<Models.Provider>($"{Apiurl}", provider);
        }

        public async Task<Models.Provider> UpdateProviderAsync(Models.Provider provider)
        {
            return await PutJsonAsync<Models.Provider>($"{Apiurl}/{provider.Id}", provider);
        }

        public async Task DeleteProviderAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }
    }
}
