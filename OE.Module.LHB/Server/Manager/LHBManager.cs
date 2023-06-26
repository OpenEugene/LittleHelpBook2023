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
        private readonly ILHBRepository _LHBRepository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public LHBManager(ILHBRepository LHBRepository, IDBContextDependencies DBContextDependencies)
        {
            _LHBRepository = LHBRepository;
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
            List<Models.LHB> LHBs = _LHBRepository.GetLHBs(module.ModuleId).ToList();
            if (LHBs != null)
            {
                content = JsonSerializer.Serialize(LHBs);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
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
