using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

using M = OE.Module.LHB.Shared.Models;
using OE.Module.LHB.Shared.ViewModels;
using System.Security.Cryptography;

namespace OE.Module.LHB.Repository
{
    public partial class LHBRepository
    {

        public IEnumerable<M.Provider> GetProviders()
        {
            var list = _db.Provider.AsNoTracking();
            return list;
        }

        public M.Provider GetProvider(int id)
        {
            return GetProvider(id, true);
        }

        public M.Provider GetProvider(int id, bool tracking) {
            return tracking ? _db.Provider.Find(id) : _db.Provider.AsNoTracking().FirstOrDefault(item => item.ProviderId == id);
        }

        public ProviderViewModel GetProviderViewModel(int id) {
            var provider = GetProvider(id);
            if (provider == null)
            {
                return null;
            }
            var vm = new ProviderViewModel(provider);
            vm.Addresses = GetAddressesByProviderId(id);
            
            return vm;
        }


        public M.Provider AddProvider(M.Provider item)
        {
            _db.Provider.Add(item);
            _db.SaveChanges();
            return item;
        }

        public M.Provider UpdateProvider(M.Provider providerId)
        {
            _db.Entry(providerId).State = EntityState.Modified;
            _db.SaveChanges();
            return providerId;
        }

        public void DeleteProvider(int providerId)
        {
            var item = _db.Provider.Find(providerId);

            if (item == null) return;
            _db.Provider.Remove(item);
            _db.SaveChanges();

        }
    }
}
