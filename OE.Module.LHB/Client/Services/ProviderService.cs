using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OE.Module.LHB.Shared.ViewModels;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using M=OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Services
{
    public class ProviderService : ServiceBase, IService
    {
        public ProviderService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Provider");

        public async Task<List<M.Provider>> GetProvidersAsync()
        {
            List<M.Provider> list = await GetJsonAsync<List<M.Provider>>($"{Apiurl}");
            if (list != null)
            {
                return list.OrderBy(item => item.Name).ToList();
            }
            return null;
        }

        public async Task<M.Provider> GetProviderAsync(int id)
        {
            return await GetJsonAsync<M.Provider>($"{Apiurl}/{id}");
        }

        public async Task<ProviderViewModel> GetProviderViewModelAsync(int id)
        {
            var vm = await GetJsonAsync<ProviderViewModel>($"{Apiurl}/vm/{id}");
            return vm;
        }

        public async Task<M.Provider> AddProviderAsync(M.Provider item)
        {
            return await PostJsonAsync<M.Provider>($"{Apiurl}", item);
        }

        public async Task<M.Provider> UpdateProviderAsync(M.Provider item)
        {
            return await PutJsonAsync<M.Provider>($"{Apiurl}/{item.ProviderId}", item);
        }

        public async Task<ProviderViewModel> UpdateProviderAsync(ProviderViewModel item)
        {
            return await PutJsonAsync<ProviderViewModel>($"{Apiurl}/vm/{item.ProviderId}", item);
        }

        public async Task DeleteProviderAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }

        public async Task<List<ProviderAttributeViewModel>> GetAttributesForProviderAsync(int id) {
            var vm = await GetJsonAsync<List<ProviderAttributeViewModel>>($"{Apiurl}/ProviderAttributes/{id}");
            return vm;
        }
        public async Task DeleteAttributeAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/ProviderAttribute/{id}");
        }
        public async Task<M.ProviderAttribute> AddProviderAttribute(M.ProviderAttribute item)
        {
            item.EnsureIAuditable();
            return await PostJsonAsync<M.ProviderAttribute>($"{Apiurl}/ProviderAttribute", item);
        }

    }
}
