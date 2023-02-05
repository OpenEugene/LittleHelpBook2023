using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using OE.LHB.Models;

namespace OE.LHB.Repository
{
    public class ProviderRepository : ITransientService
    {
        private readonly LHBContext _db;

        public ProviderRepository(LHBContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Provider> GetProviders()
        {
            return _db.Providers.AsNoTracking();
        }

        public Models.Provider GetProvider(int id)
        {
            return GetProvider(id, true);
        }

        public Models.Provider GetProvider(int id, bool tracking)
        {
            if (tracking)
            {
                return _db.Providers.Find(id);
            }
            else
            {
                return _db.Providers.AsNoTracking().FirstOrDefault(item => item.Id == id);
            }
        }

        public Models.Provider AddProvider(Models.Provider provider)
        {
            _db.Providers.Add(provider);
            _db.SaveChanges();
            return provider;
        }

        public Models.Provider UpdateProvider(Models.Provider provider)
        {
            _db.Entry(provider).State = EntityState.Modified;
            _db.SaveChanges();
            return provider;
        }

        public void DeleteProvider(int id)
        {
            Models.Provider LHB = _db.Providers.Find(id);
            _db.Providers.Remove(LHB);
            _db.SaveChanges();
        }
    }
}
