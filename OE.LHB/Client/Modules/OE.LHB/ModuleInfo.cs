using Oqtane.Models;
using Oqtane.Modules;

namespace OE.LHB
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "LHB",
            Description = "LHB",
            Version = "1.0.0",
            ServerManagerType = "OE.LHB.Manager.LHBManager, OE.LHB.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "OE.LHB.Shared.Oqtane",
            PackageName = "OE.LHB" 
        };
    }
}
