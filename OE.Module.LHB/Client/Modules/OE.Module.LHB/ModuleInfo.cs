using Oqtane.Models;
using Oqtane.Modules;

namespace OE.Module.LHB
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "LHB",
            Description = "The Little Help Book",
            Version = "1.0.0",
            ServerManagerType = "OE.Module.LHB.Manager.LHBManager, OE.Module.LHB.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "OE.Module.LHB.Shared.Oqtane",
            PackageName = "OE.Module.LHB" 
        };
    }
}
