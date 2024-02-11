using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OE.Module.LHB.Shared.ViewModels;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using M=OE.Module.LHB.Shared.Models;


namespace OE.Module.LHB.Services
{
    public class AttributeService : ServiceBase, IService
    {
        public AttributeService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Attribute");

        public async Task<List<M.Attribute>> GetAttributesAsync()
        {
            List<M.Attribute> list = await GetJsonAsync<List<M.Attribute>>($"{Apiurl}");
            if (list != null)
            {
                return list.OrderBy(item => item.Name).ToList();
            }
            return null;
        }


        public async Task<M.Attribute> AddAttributeAsync(M.Attribute item)
        {
            item.EnsureIAuditable();
            return await PostJsonAsync<M.Attribute>($"{Apiurl}", item);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }
    }
}
