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
    public class AddressService : ServiceBase, IService
    {
        public AddressService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Address");

        public async Task<M.Address> AddAddressAsync(M.Address item)
        {
            item.EnsureIAuditable();

            return await PostJsonAsync<M.Address>($"{Apiurl}", item);
            
        }

        public async Task DeleteAddressAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }
    }
}
