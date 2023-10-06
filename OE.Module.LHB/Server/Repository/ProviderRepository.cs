using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

using M = OE.Module.LHB.Shared.Models;
using OE.Module.LHB.Shared.ViewModels;

namespace OE.Module.LHB.Repository
{
    public partial class LHBRepository
    {

        public IEnumerable<M.Provider> GetProviders()
        {
            return _db.Provider.AsNoTracking();
        }

        public M.Provider GetProvider(int id)
        {
            return GetProvider(id, true);
        }

        public M.Provider GetProvider(int id, bool tracking) {
            return tracking ? _db.Provider.Find(id) : _db.Provider.AsNoTracking().FirstOrDefault(item => item.ProviderId == id);
        }

        public List<ProviderViewModel> GetProviderViewModel(int id) {
            var list = from p in _db.Provider
                join pa in _db.ProviderAddress on p.ProviderId equals pa.ProviderId
                join a in _db.Address on pa.AddressId equals a.AddressId
                where p.ProviderId == id
                select new ProviderViewModel {
                    ProviderId = p.ProviderId,
                    Name = p.Name,
                    //Addresses = new M.Address {
                    //    AddressId = a.AddressId,
                    //    Address1 = a.Address1,
                    //    Address2 = a.Address2,
                    //    City = a.City,
                    //    State = a.State,
                    //    PostalCode = a.PostalCode
                    //}
                };
            return null;

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
