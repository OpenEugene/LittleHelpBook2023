using Oqtane.Models;
using Oqtane.Modules;

namespace OE.Module.Provider
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Provider",
            Description = "Providers",
            Version = "1.0.1",
            ServerManagerType = "OE.Module.LHB.Manager.LHBManager, OE.Module.LHB.Server.Oqtane",
            ReleaseVersions = "1.0.1",
            Dependencies = "OE.Module.LHB.Shared.Oqtane",
            PackageName = "OE.Module.LHB"
        };
    }
}
