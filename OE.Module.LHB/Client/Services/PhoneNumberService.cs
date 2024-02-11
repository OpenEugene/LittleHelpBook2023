using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using M=OE.Module.LHB.Shared.Models;


namespace OE.Module.LHB.Services
{
    public class PhoneNumberService : ServiceBase, IService
    {
        public PhoneNumberService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("PhoneNumber");

        public async Task<M.PhoneNumber> AddPhoneNumberAsync(M.PhoneNumber item)
        {
            item.EnsureIAuditable();
            return await PostJsonAsync<M.PhoneNumber>($"{Apiurl}", item);
            
        }

        public async Task DeletePhoneNumberAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }
    }
}
