using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace OE.Module.LHB.Repository
{
    public class LHBContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.LHB> LHB { get; set; }

        public LHBContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
