using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OE.LHB.Models;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace OE.LHB.Services
{
    public class ResourceService : ServiceBase, IService
    {
        public ResourceService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Resource");
        
        public async Task<List<Models.Resource>> GetResourcesAsync()
        {
            var resources = await GetJsonAsync<List<Models.Resource>>($"{Apiurl}");
            return resources.Any()? resources.OrderBy(item => item.Name).ToList() : new List<Resource>();
        }

        public async Task<Models.Resource> GetResourceAsync(int id)
        {
            return await GetJsonAsync<Models.Resource>($"{Apiurl}/{id}");
        }

        public async Task<Models.Resource> AddResourceAsync(Models.Resource resource)
        {
            return await PostJsonAsync<Models.Resource>($"{Apiurl}", resource);
        }

        public async Task<Models.Resource> UpdateResourceAsync(Models.Resource resource)
        {
            return await PutJsonAsync<Models.Resource>($"{Apiurl}/{resource.Id}", resource);
        }

        public async Task DeleteResourceAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }
    }
}
