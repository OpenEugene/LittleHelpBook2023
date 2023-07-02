using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

using M = OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Repository
{
    public class ProviderRepository :  ITransientService
    {
        private readonly LHBContext _db;

        public ProviderRepository(LHBContext context)
        {
            _db = context;
        }

        public IEnumerable<M.Provider> GetProviders()
        {
            return _db.Provider.AsNoTracking();
        }

        public M.Provider GetProvider(int id)
        {
            return GetProvider(id, true);
        }

        public M.Provider GetProvider(int id, bool tracking)
        {
            if (tracking)
            {
                return _db.Provider.Find(id);
            }
            else
            {
                return _db.Provider.AsNoTracking().FirstOrDefault(item => item.ProviderId == id);
            }
        }

        public M.Provider AddProvider(M.Provider item)
        {
            _db.Provider.Add(item);
            _db.SaveChanges();
            return item;
        }

        public M.Provider UpdateLHB(M.Provider LHB)
        {
            _db.Entry(LHB).State = EntityState.Modified;
            _db.SaveChanges();
            return LHB;
        }

        public void DeleteLHB(int LHBId)
        {
            M.Provider LHB = _db.Provider.Find(LHBId);
            _db.Provider.Remove(LHB);
            _db.SaveChanges();
        }
    }
}
