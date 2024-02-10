using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;
using M=OE.Module.LHB.Shared.Models;

namespace OE.Module.LHB.Repository
{
    public class LHBContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<M.Address> Address { get; set; }
        public virtual DbSet<M.Attribute> Attribute { get; set; }
        public virtual DbSet<M.PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<M.Provider> Provider { get; set; }
        public virtual DbSet<M.ProviderAddress> ProviderAddress { get; set; }
 
        public LHBContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
