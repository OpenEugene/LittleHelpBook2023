using System.Collections.Generic;
using Oqtane.Models;
using Oqtane.Themes;
using Oqtane.Shared;
using static MudBlazor.CategoryTypes;

namespace OE.Theme.LHB
{
    public class ThemeInfo : ITheme
    {
        public Oqtane.Models.Theme Theme => new Oqtane.Models.Theme
        {
            Name = "LHB Theme",
            Version = "1.0.0",
            PackageName = "OE.Theme.LHB",
            Resources = new List<Resource>()
            {
                new Resource { ResourceType = ResourceType.Script, Url = "_content/MudBlazor_oqtane/MudBlazor.min.js",Level=ResourceLevel.Site },
            }
        };

    }
}
