using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using OE.Module.LHB.Models;

namespace OE.Module.LHB.Repository
{
    public class LHBRepository : ILHBRepository, ITransientService
    {
        private readonly LHBContext _db;

        public LHBRepository(LHBContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.LHB> GetLHBs(int ModuleId)
        {
            return _db.LHB.Where(item => item.ModuleId == ModuleId);
        }

        public Models.LHB GetLHB(int LHBId)
        {
            return GetLHB(LHBId, true);
        }

        public Models.LHB GetLHB(int LHBId, bool tracking)
        {
            if (tracking)
            {
                return _db.LHB.Find(LHBId);
            }
            else
            {
                return _db.LHB.AsNoTracking().FirstOrDefault(item => item.LHBId == LHBId);
            }
        }

        public Models.LHB AddLHB(Models.LHB LHB)
        {
            _db.LHB.Add(LHB);
            _db.SaveChanges();
            return LHB;
        }

        public Models.LHB UpdateLHB(Models.LHB LHB)
        {
            _db.Entry(LHB).State = EntityState.Modified;
            _db.SaveChanges();
            return LHB;
        }

        public void DeleteLHB(int LHBId)
        {
            Models.LHB LHB = _db.LHB.Find(LHBId);
            _db.LHB.Remove(LHB);
            _db.SaveChanges();
        }
    }
}
