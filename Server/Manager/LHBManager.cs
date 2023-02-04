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
    public class LHBManager : MigratableModuleBase, IInstallable, IPortable
    {
        private ILHBRepository _LHBRepository;
        private readonly ITenantManager _tenantManager;
        private readonly IHttpContextAccessor _accessor;

        public LHBManager(ILHBRepository LHBRepository, ITenantManager tenantManager, IHttpContextAccessor accessor)
        {
            _LHBRepository = LHBRepository;
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
            string content = "";
            List<Models.LHB> LHBs = _LHBRepository.GetLHBs(module.ModuleId).ToList();
            if (LHBs != null)
            {
                content = JsonSerializer.Serialize(LHBs);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Models.LHB> LHBs = null;
            if (!string.IsNullOrEmpty(content))
            {
                LHBs = JsonSerializer.Deserialize<List<Models.LHB>>(content);
            }
            if (LHBs != null)
            {
                foreach(var LHB in LHBs)
                {
                    _LHBRepository.AddLHB(new Models.LHB { ModuleId = module.ModuleId, Name = LHB.Name });
                }
            }
        }
    }
}