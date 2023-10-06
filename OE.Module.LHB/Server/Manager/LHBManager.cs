using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using OE.Module.LHB.Repository;

namespace OE.Module.LHB.Manager
{
    public class LHBManager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly LHBRepository _lhbRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public LHBManager(LHBRepository lhbRepository, IDBContextDependencies DBContextDependencies)
        {
            _lhbRepository = lhbRepository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new LHBContext(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new LHBContext(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
        }
    }
}
