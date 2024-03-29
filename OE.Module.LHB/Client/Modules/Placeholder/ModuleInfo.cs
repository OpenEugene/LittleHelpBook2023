using Oqtane.Models;
using Oqtane.Modules;

namespace OE.Module.Placeholder
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
			Name = "Placeholder",
			Description = "For holding places",
			Version = "1.0.2",
			ServerManagerType = "OE.Module.LHB.Manager.LHBManager, OE.Module.LHB.Server.Oqtane",
			ReleaseVersions = "1.0.2",
			Dependencies = "OE.Module.LHB.Shared.Oqtane",
			PackageName = "OE.Module.LHB"
		};
    }
}
