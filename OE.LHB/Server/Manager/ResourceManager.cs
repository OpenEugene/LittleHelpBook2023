using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using OE.LHB.Repository;

namespace OE.LHB.Manager
{
    public class ResourceManager : MigratableModuleBase, IInstallable, IPortable
    {
        private ProviderRepository _repository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public ResourceManager(ProviderRepository repository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _tenantManager = tenantManager;
            _accessor = accessor;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new LHBContext(_tenantManager, _accessor), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new LHBContext(_tenantManager, _accessor), tenant, MigrationType.Down);
        }

        public string ExportModule(Module module)
        {
            return null;
        }

        public void ImportModule(Module module, string content, string version)
        {
          
        }
    }
}