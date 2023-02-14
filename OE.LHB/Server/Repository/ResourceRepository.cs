using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using OE.LHB.Models;

namespace OE.LHB.Repository
{
    public class ResourceRepository : ITransientService
    {
        private readonly LHBContext _db;

        public ResourceRepository(LHBContext context)
        {
            _db = context;
        }

        public IEnumerable<Resource> GetResources()
        {
            return _db.Resources.AsNoTracking();
        }

        public Resource GetResource(int id)
        {
            return GetResource(id, true);
        }

        public Resource GetResource(int id, bool tracking)
        {
            if (tracking)
            {
                return _db.Resources.Find(id);
            }
            else
            {
                return _db.Resources.AsNoTracking().FirstOrDefault(item => item.Id == id);
            }
        }

        public Resource AddResource(Resource resource)
        {
            _db.Resources.Add(resource);
            _db.SaveChanges();
            return resource;
        }

        public Resource UpdateResource(Resource resource)
        {
            _db.Entry(resource).State = EntityState.Modified;
            _db.SaveChanges();
            return resource;
        }

        public void DeleteResource(int id)
        {
            var resource = _db.Resources.Find(id);
            _db.Resources.Remove(resource);
            _db.SaveChanges();
        }
    }
}
